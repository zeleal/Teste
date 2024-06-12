﻿using Application.Interfaces;
using Application.Requests.CidadeRequests;
using Application.Requests.EmpresaRequests;
using Application.Requests.UsuarioEmpresaRequests;
using Application.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsuariosEmpresasController : ControllerBase
    {
        private readonly IUsuarioEmpresaService _service;

        public UsuariosEmpresasController(IUsuarioEmpresaService service) => _service = service;
        
        /// <summary>
        /// Adiciona novo vinculo Usuario e Empresa.
        /// </summary>
        /// <response code="200">Adiciona novo vinculo Usuario e Empresa.</response>
        /// <response code="400">Erro ao adicionar Vinculo Usuario/Empresa.</response>
        //[Route("AdicionarUsuarioEmpresa")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<UsuarioEmpresaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarUsuarioEmpresa([FromBody] UsuarioEmpresaDto request)
        {
            var usuarioEmpresa = await _service.AdicionarAsync(new AdicionarUsuarioEmpresaRequest(request));

            if (usuarioEmpresa == null)
            {
                return BadRequest();
            }
            return Ok(new { usuarioEmpresa });
        }

        /// <summary>
        /// Obtém uma lista com Todos os Vinculos entre Usuario/Empresa.
        /// </summary>
        /// <response code="200">Retorna a lista com Todos os Vinculos entre Usuario/Empresa.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UsuarioEmpresaDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosAsync()
            => (await _service.ObterTodosAsync()).ToActionResult();

        /// <summary>
        /// Obtém as Empresas vinculadas ao CPF.
        /// </summary>
        /// <param name="cpf">Sigle para identificar o Usuario.</param>
        /// <response code="200">Retorna as Empresas Vinculadas ao Usuario.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhuma empresa é encontrada.</response>
        [HttpGet("ObterEmpresaPorCpf/{Cpf}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmpresaDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterEmpresasVinculadosCpf([FromRoute] string Cpf)
        {
            if (Cpf == null)
            {
                BadRequest();
            }

            Cpf = Cpf.Replace(".", "").Replace("-", "");

            if (Regex.IsMatch(Cpf, @"^[0-9]+$"))
            {
                return (await _service.ObterEmpresaPorUsuarioAsync(new ObterEmpresaPorUsuarioRequest(Cpf))).ToActionResult();
            }
            else
            {
                return BadRequest("O Cpf deve contem apenas números");
            }

        }

        /// <summary>
        /// Obtém as Usuarios vinculadas ao Cnpj.
        /// </summary>
        /// <param name="Cnpj">Sigla para identificar o Empresa.</param>
        /// <response code="200">Retorna os Usuarios Vinculadas a Empresa.</response>
        /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
        /// <response code="404">Quando nenhum Usuario é encontrado.</response>
        [HttpGet("ObterUsuarioPorCnpj/{Cnpj:alpha}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UsuarioDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterUsuariosVinculadosCnpj([FromRoute] string Cnpj)
        {
            if (Cnpj == null)
            {
                BadRequest("O campo CNPJ não pode ser Null.");
            }
            Cnpj = Cnpj.Replace(".", "").Replace("-", "");

            return (await _service.ObterUsuarioPorEmpresaAsync(new ObterUsuarioPorEmpresaRequest(Cnpj))).ToActionResult();
        }
    }
}
