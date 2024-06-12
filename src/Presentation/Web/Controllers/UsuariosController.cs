using Application.Interfaces;
using Application.Requests;
using Application.Requests.EmpresaRequests;
using Application.Requests.UsuarioRequests;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service) => _service = service;

        /// <summary>
        /// Adiciona Novo Usuario.
        /// </summary>
        /// <response code="200">Adiciona novo Usuario.</response>
        /// <response code="400">Erro ao adicionar Usuario.</response>
        //[Route("AdicionarUsuario")]
        [HttpPost("Adicionar")]
        [ProducesResponseType(typeof(ApiResponse<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarUsuarios([FromBody] UsuarioDto request)
        {
            var usuario = await _service.AdicionarAsync(new AdicionarRequest(request));

            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(new { usuario });
        }

        /// <summary>
        /// Atualiza o Usuario.
        /// </summary>
        /// <response code="200">Atualiza o Usuario.</response>
        /// <response code="400">ID de Usuario não corresponde ao ID da URL</response>
        /// <response code="404">Quando nenhum Usuario é encontrado.</response>
        //[Route("AtualizarUsuario")]
        [HttpPut("Atualizar")]
        [ProducesResponseType(typeof(ApiResponse<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarUsuario( [FromBody] UsuarioDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var usuario = await _service.AtualizarAsync(new AtualizarRequest(request));

            return Ok(new { usuario });
        }

        /// <summary>
        /// Obtém uma lista com todos os Usuarios.
        /// </summary>
        /// <response code="200">Retorna a lista de Usuarios.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        [HttpGet("buscartodos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UsuarioDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
            => (await _service.ObterTodosAsync()).ToActionResult();

        /// <summary>
        /// Obtém o Usuario pelo Id.
        /// </summary>
        /// <param name="id">Id do Usuario.</param>
        /// <response code="200">Retorna o Usuario.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum Usuario é encontrada.</response>
        [HttpGet("obterporid/{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] Guid id)
            => (await _service.ObterPorIdAsync(new GetByIdRequest(id))).ToActionResult();
    }
}
