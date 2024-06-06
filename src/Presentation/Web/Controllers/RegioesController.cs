using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Web.Extensions;
using Web.Models;
using Domain.Dto;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class RegioesController : ControllerBase
{
    private readonly IRegiaoService _service;

    public RegioesController(IRegiaoService service) => _service = service;

    /// <summary>
    /// Obtém uma lista com todas as regiões.
    /// </summary>
    /// <response code="200">Retorna a lista de regiões.</response>
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<RegiaoDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterTodosAsync()
        => (await _service.ObterTodosAsync()).ToActionResult();
}