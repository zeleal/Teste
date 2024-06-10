using Application.Interfaces;
using Application.Requests.UsuarioRequests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _service;

        public EnderecosController(IEnderecoService service) => _service = service;


    }
}
