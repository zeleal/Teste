using Application.Interfaces;
using Application.Requests.EnderecoRequests;
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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        public EnderecoController(IEnderecoService service) => _service = service;

        /// <summary>
        /// Obtém o Endereço pelo Usuario CPF.rr
        /// </summary>
        /// <param name="cpf">Código de Usuario.</param>
        /// <response code="200">Retorna a Endereço do Usuario pelo CPF.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum endereço é encontrado para o CPF do Usuario.</response>
        [HttpGet("{cpf:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<EnderecoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterEnderecoPorUsuarioAsync([FromRoute] int cpf)
            => (await _service.ObterEnderecoPorUsuarioAsync(new ObterEnderecoPorUsuarioRequests(cpf))).ToActionResult();
    }
}
