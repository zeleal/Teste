using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service) => _service = service;

        public IActionResult Index()
        {
            return View();
        }
    }
}
