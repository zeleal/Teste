using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Web.ObjectResults;

[DefaultStatusCode(StatusCodes.Status500InternalServerError)]
public sealed class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult([ActionResultObjectValue] object value) : base(value)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }
}