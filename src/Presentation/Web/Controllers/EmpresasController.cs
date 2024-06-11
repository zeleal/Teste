using Application.Interfaces;
using Application.Requests;
using Application.Requests.CidadeRequests;
using Application.Requests.EmpresaRequests;
using Application.Services;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Domain.Entities;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _service;

        public EmpresasController(IEmpresaService service) => _service = service;

        /// <summary>
        /// Adiciona Nova Empresa.
        /// </summary>
        /// <response code="200">Adiciona nova Empresa.</response>
        /// <response code="400">Erro ao adicionar empresa.</response>
        //[Route("AdicionarEmpresa")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<EmpresaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarEmpresa([FromBody] EmpresaDto request)
        {
            var empresa = await _service.AdicionarAsync(new AdicionarEmpresaRequests(request));

            if (empresa == null)
            {
                return BadRequest();
            }
            return Ok(new { empresa });
        }

        /// <summary>
        /// Atualiza a Empresa.
        /// </summary>
        /// <response code="200">Atualiza a Empresa.</response>
        /// <response code="400">ID de empresa não corresponde ao ID da URL</response>
        /// <response code="404">Quando nenhuma Empresa é encontrada.</response>
        //[Route("AtualizaEmpresa")]
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<EmpresaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarEmpresa([FromBody] EmpresaDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var empresa = await _service.AtualizarAsync(new AtualizarEmpresaRequest(request));

            return Ok(new { empresa });
        }

        /// <summary>
        /// Obtém uma lista com todas as Empresas.
        /// </summary>
        /// <response code="200">Retorna a lista de Empresas.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmpresaDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
            => (await _service.ObterTodosAsync()).ToActionResult();


        /// <summary>
        /// Obtém a Empresa pelo Id.
        /// </summary>
        /// <param name="id">Id da Empresa.</param>
        /// <response code="200">Retorna a Empresa.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhuma Empresa é encontrada.</response>
        [HttpGet("{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<EmpresaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] Guid id)
            => (await _service.ObterPorIdAsync(new GetByIdRequest(id))).ToActionResult();
    }
}