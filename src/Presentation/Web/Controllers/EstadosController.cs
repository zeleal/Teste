using Web.Models;
using Domain.Dto;
using Web.Extensions;
using System.Net.Mime;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Requests.EstadoRequests;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class EstadosController : ControllerBase
{
    private readonly IEstadoService _service;

    public EstadosController(IEstadoService service) => _service = service;

    /// <summary>
    /// Obtém uma lista com todos os estados.
    /// </summary>
    /// <response code="200">Retorna a lista de estados.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<EstadoDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterTodosAsync()
        => (await _service.ObterTodosAsync()).ToActionResult();

    /// <summary>
    /// Obtém uma lista de estados pelo nome da região.
    /// </summary>
    /// <param name="regiao">Nome da região, exemplo: Norte, Nordeste, Sudeste, Sul e Centro-Oeste.</param>
    /// <response code="200">Retorna a cidade.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum estado é encontrado pelo nome da região fornecida.</response>
    [HttpGet("{regiao}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<EstadoDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterPorIbgeAsync([FromRoute] string regiao)
        => (await _service.ObterTodosPorRegiaoAsync(new ObterTodosPorRegiaoRequest(regiao))).ToActionResult();
}