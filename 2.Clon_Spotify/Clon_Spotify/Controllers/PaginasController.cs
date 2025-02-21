using Microsoft.AspNetCore.Mvc;

namespace Clon_Spotify.Controllers
{
    public class PaginasController : Controller
    {
        public IActionResult CrearCuenta()
        {
            return View();
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }

        public IActionResult RestablecerContrasenia()
        {
            return View();
        }
    }
}
