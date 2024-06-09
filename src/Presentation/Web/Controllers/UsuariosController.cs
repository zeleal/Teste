using Application.Interfaces;
using Application.Requests.UsuarioRequests;
using Domain.Dto;
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
        /// Obtém o Endereço pelo Usuario.rr
        /// </summary>
        /// <param name="id">Código de Usuario.</param>
        /// <response code="200">Retorna a Endereço do Usuario.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum endereço é encontrado para o Usuario.</response>
        [HttpGet("{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterUsuarioEnderecoAsync([FromRoute] Guid id)
            => (await _service.ObterUsuarioEnderecoAsync(new ObterUsuarioEnderecoRequest(id))).ToActionResult();



        /// <summary>
        /// Obtém uma lista com todos os Usuarios.
        /// </summary>
        /// <response code="200">Retorna a lista de Usuarios.</response>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UsuarioDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
            => (await _service.ObterTodosAsync()).ToActionResult();
    }
}