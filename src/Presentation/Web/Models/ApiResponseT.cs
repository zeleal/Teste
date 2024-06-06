using Microsoft.AspNetCore.Http;

namespace Web.Models;

/// <inheritdoc />
public sealed class ApiResponse<T> : ApiResponse
{
    public T Result { get; private init; }

    /// <summary>
    /// Cria uma resposta com HTTP Status 200.
    /// </summary>
    public static ApiResponse<T> Ok(T result)
        => new() { Success = true, StatusCode = StatusCodes.Status200OK, Result = result };
}