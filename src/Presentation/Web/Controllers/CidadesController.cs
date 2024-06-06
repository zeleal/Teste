using Web.Models;
using Domain.Dto;
using Web.Extensions;
using System.Net.Mime;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Requests.CidadeRequests;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class CidadesController : ControllerBase
{
    private readonly ICidadeService _service;

    public CidadesController(ICidadeService service) => _service = service;

    /// <summary>
    /// Obtém uma lista de cidades pelo código UF.
    /// </summary>
    /// <param name="uf">Sigla da unidade federativa (UF).</param>
    /// <response code="200">Retorna a lista de cidades.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhuma cidade é encontrada pelo UF fornecido.</response>
    [HttpGet("{uf:alpha}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<CidadeDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterTodosPorUfAsync([FromRoute] string uf)
        => (await _service.ObterTodosPorUfAsync(new ObterTodosPorUfRequest(uf))).ToActionResult();

    /// <summary>
    /// Obtém a cidade pelo código de IBGE.
    /// </summary>
    /// <param name="ibge">Código de IBGE.</param>
    /// <response code="200">Retorna a cidade.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhuma cidade é encontrada pelo IBGE fornecido.</response>
    [HttpGet("{ibge:int}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<CidadeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterPorIbgeAsync([FromRoute] int ibge)
        => (await _service.ObterPorIbgeAsync(new ObterPorIbgeRequest(ibge))).ToActionResult();
}