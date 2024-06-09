using Application.Interfaces;
using Application.Requests.UsuarioEmpresaRequests;
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
    public class UsuarioEmpresaController : ControllerBase
    {
        private readonly IUsuarioEmpresaService _service;

        public UsuarioEmpresaController(IUsuarioEmpresaService service) => _service = service;

        /// <summary>
        /// Obtém as Empresas vinculadas ao CPF.
        /// </summary>
        /// <param name="cpf">Sigle para identificar o Usuario.</param>
        /// <response code="200">Retorna as Empresas Vinculadas ao Usuario.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhuma empresa é encontrada.</response>
        [HttpGet("{cpf:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmpresaDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterEmpresaPorUsuarioAsync([FromRoute] int cpf)
            => (await _service.ObterEmpresaPorUsuarioAsync(new ObterEmpresaPorUsuarioRequest(cpf))).ToActionResult();

        /// <summary>
        /// Obtém as Usuarios vinculadas ao Cnpj.
        /// </summary>
        /// <param name="cnpj">Sigla para identificar o Empresa.</param>
        /// <response code="200">Retorna os Usuarios Vinculadas a Empresa.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum Usuario é encontrado.</response>
        [HttpGet("{cnpj:string}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UsuarioDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterUsuarioPorEmpresaAsync([FromRoute] string cnpj)
            => (await _service.ObterUsuarioPorEmpresaAsync(new ObterUsuarioPorEmpresaRequest(cnpj))).ToActionResult();
    }
}
