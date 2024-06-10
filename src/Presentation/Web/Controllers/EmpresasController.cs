using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmpresasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
