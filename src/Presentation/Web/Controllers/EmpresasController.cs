using Application.Interfaces;
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
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _service;
        public EmpresasController(IEmpresaService service) => _service = service;



        ///// <summary>
        ///// Obtém uma lista com todos os Empresas.
        ///// </summary>
        ///// <response code="200">Retorna a lista de Empresas.</response>
        //[HttpGet]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(ApiResponse<IEnumerable<EmpresaDto>>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> ObterTodosAsync()
        //    => (await _service.ObterTodosAsync()).ToActionResult();
    }
}
