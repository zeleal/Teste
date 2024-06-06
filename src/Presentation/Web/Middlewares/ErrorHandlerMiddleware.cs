using Web.Models;
using System.Net.Mime;
using Shared.Extensions;

namespace Web.Middlewares;

public class ErrorHandlerMiddleware
{
    private const string DefaultErrorMessage = "Ocorreu um erro interno ao processar a sua solicitação.";

    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ErrorHandlerMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Foi gerada uma exceção não esperada: {Message}", ex.Message);

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Quando for ambiente de desenvolvimento, será exibida a stack trace completa da exception.
            var errorMessage = _environment.IsDevelopment() ? ex.ToJson() : DefaultErrorMessage;
            await context.Response.WriteAsync(ApiResponse.InternalServerError(errorMessage).ToJson());
        }
    }
}