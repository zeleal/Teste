using Application.Interfaces;
using Application.Requests;
using Application.Requests.EnderecoRequests;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Web.Extensions;
using Web.Models;
using AdicionarRequest = Application.Requests.EnderecoRequests.AdicionarRequest;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _service;

        public EnderecosController(IEnderecoService service) => _service = service;

        /// <summary>
        /// Adiciona Novo Endereço.
        /// </summary>
        /// <response code="200">Adiciona novo Endereço.</response>
        /// <response code="400">Erro ao adicionar Endereço.</response>
        //[Route("AdicionarUsuario")]
        [HttpPost("Adicionarendereco")]
        [ProducesResponseType(typeof(ApiResponse<EnderecoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarUsuarios([FromBody] EnderecoDto request)
        {
            var endereco = await _service.AdicionarAsync(new AdicionarRequest(request));

            if (endereco == null)
            {
                return BadRequest();
            }
            return Ok(new { endereco });
        }

        /// <summary>
        /// Atualiza o Endereço.
        /// </summary>
        /// <response code="200">Atualiza o Usuario.</response>
        /// <response code="400">ID de Endreço não corresponde ao ID da URL</response>
        /// <response code="404">Quando nenhum endereço é encontrado.</response>
        //[Route("AtualizarUsuario")]
        [HttpPut("Atualizarendereco")]
        [ProducesResponseType(typeof(ApiResponse<EnderecoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarUsuario([FromBody] EnderecoDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var endereco = await _service.AtualizarAsync(new AtualizarRequest(request));

            return Ok(new { endereco });
        }

        /// <summary>
        /// Obtém uma lista com todos os Endereços.
        /// </summary>
        /// <response code="200">Retorna a lista de Endereços.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum endereço é encontrado.</response> 
        [HttpGet("buscartodosenderecos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EnderecoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
            => (await _service.ObterTodosAsync()).ToActionResult();

        /// <summary>
        /// Obtém o Endereços pelo Id.
        /// </summary>
        /// <param name="id">Id do Endereços.</param>
        /// <response code="200">Retorna o Endereços.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum Endereços é encontrada.</response>
        [HttpGet("obterporid/{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<EnderecoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] Guid id)
            => (await _service.ObterPorIdAsync(new GetByIdRequest(id))).ToActionResult();
    }
}
