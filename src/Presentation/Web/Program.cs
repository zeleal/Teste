using Shared;
using AutoMapper;
using System.Linq;
using Application;
using Infrastructure;
using Web.Extensions;
using Web.Middlewares;
using FluentValidation;
using Shared.Extensions;
using Shared.AppSettings;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Text.Json;
using StackExchange.Profiling;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Resources;
using Infrastructure.Data.Context;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
builder.Services.Configure<KestrelServerOptions>(options => options.AddServerHeader = false);
builder.Services.Configure<MvcNewtonsoftJsonOptions>(options => options.SerializerSettings.Configure());
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddHttpLogging(logging => {
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
builder.Services.AddCache(builder.Configuration);
builder.Services.AddApiVersioningAndApiExplorer();
builder.Services.AddOpenApi();
builder.Services.ConfigureAppSettings();
builder.Services.AddJwtBearer(builder.Configuration, builder.Environment.IsProduction());
builder.Services.AddServices();
builder.Services.AddInfrastructure();
builder.Services.AddRepositories();

// Add services to the container.
builder.Services.AddControllersWithViews();

var healthChecksBuilder = builder.Services.AddHealthChecks().AddGCInfoCheck();
builder.Services.AddSpgContext(healthChecksBuilder);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
        options.SuppressModelStateInvalidFilter = true;
    }).AddNewtonsoftJson();

// MiniProfiler for .NET
// https://miniprofiler.com/dotnet/
builder.Services.AddMiniProfiler(options =>
{
    // Route: /profiler/results-index
    options.RouteBasePath = "/profiler";
    options.ColorScheme = ColorScheme.Dark;
    options.EnableServerTimingHeader = true;

    if (builder.Environment.IsDevelopment())
    {
        options.EnableDebugMode = true;
        options.TrackConnectionOpenClose = true;
    }
}).AddEntityFramework();


builder.Host.UseDefaultServiceProvider((context, options) =>
{
options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
options.ValidateOnBuild = true;
});

builder.WebHost.UseKestrel();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDeveloperExceptionPage();

// Configuração global do FluentValidation.
ValidatorOptions.Global.DisplayNameResolver = (_, member, _) => member?.Name;
ValidatorOptions.Global.LanguageManager = new LanguageManager { Culture = new CultureInfo("pt-Br") };

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseSwaggerAndUI(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());
app.UseHealthChecks();
app.UseHttpsRedirection();
app.UseHsts();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpLogging();
app.UseResponseCompression();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiniProfiler();
app.MapControllers();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is ValidationException validationException)
        {
            var errors = validationException.Errors.Select(e => new
            {
                PropertyName = e.PropertyName,
                ErrorMessage = e.ErrorMessage,
                AttemptedValue = e.AttemptedValue
            });

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                success = false,
                statusCode = 400,
                errors
            }));
        }
        else
        {
            // Tratamento para outros tipos de exceção, se necessário
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                success = false,
                statusCode = 500,
                errors = new[] { "Um erro inesperado ocorreu. Por favor, tente novamente mais tarde." }
            }));
        }
    });
});

await using var serviceScope = app.Services.CreateAsyncScope();
await using var context = serviceScope.ServiceProvider.GetRequiredService<SgpContext>();
var mapper = serviceScope.ServiceProvider.GetRequiredService<IMapper>();
var inMemoryOptions = serviceScope.ServiceProvider.GetOptions<InMemoryOptions>();

try
{
app.Logger.LogInformation("----- AutoMapper: Validando os mapeamentos...");

mapper.ConfigurationProvider.AssertConfigurationIsValid();
mapper.ConfigurationProvider.CompileMappings();

app.Logger.LogInformation("----- AutoMapper: Mapeamentos são válidos!");

if (inMemoryOptions.Cache)
{
app.Logger.LogInformation("----- Cache: InMemory");
}
else
{
app.Logger.LogInformation("----- Cache: Distributed");
}

if (inMemoryOptions.Database)
{
app.Logger.LogInformation("----- Database InMemory: Criando e migrando a base de dados...");
await context.Database.EnsureCreatedAsync();
}
else
{
var connectionString = context.Database.GetConnectionString();
app.Logger.LogInformation("----- SQL Server: {Connection}", connectionString);
app.Logger.LogInformation("----- SQL Server: Verificando se existem migrações pendentes...");

if ((await context.Database.GetPendingMigrationsAsync()).Any())
{
app.Logger.LogInformation("----- SQL Server: Criando e migrando a base de dados...");

await context.Database.MigrateAsync();

app.Logger.LogInformation("----- SQL Server: Base de dados criada e migrada com sucesso!");
}
else
{
app.Logger.LogInformation("----- SQL Server: Migrações estão em dia.");
}
}

app.Logger.LogInformation("----- Populando a base de dados...");

await context.EnsureSeedDataAsync();

app.Logger.LogInformation("----- Base de dados populada com sucesso!");
}
catch (Exception ex)
{
app.Logger.LogError(ex, "Ocorreu uma exceção ao iniciar a aplicação: {Message}", ex.Message);
throw;
}

app.Logger.LogInformation("----- Iniciado a aplicação...");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
namespace SGP.PublicApi
{
    public class Program
    {
    }
}
