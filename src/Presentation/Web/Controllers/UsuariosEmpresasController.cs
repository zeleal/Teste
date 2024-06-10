using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuariosEmpresasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
