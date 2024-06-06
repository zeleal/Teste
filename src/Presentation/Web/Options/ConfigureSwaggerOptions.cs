using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Web.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        // Add a swagger document for each discovered API version.
        // NOTE: you might choose to skip or document deprecated API versions differently.
        foreach (var description in _provider.ApiVersionDescriptions)
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var openApiInfo = new OpenApiInfo
        {
            Title = "Sistema Gerenciador de cidades e Regiões",
            Description = "ASP.NET Core C# REST API, DDD, Princípios SOLID e Clean Architecture",
            Version = description.ApiVersion.ToString(),
            Contact = new OpenApiContact
            {
                Name = "Jose Leal Marques",
                Email = "zeleal@gmail.com",
                Url = new Uri("https://www.linkedin.com/")
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://github.com/")
            }
        };

        if (description.IsDeprecated)
            openApiInfo.Description += " - Esta versão da API foi descontinuada.";

        return openApiInfo;
    }
}