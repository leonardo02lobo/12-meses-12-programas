using Clon_Spotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clon_Spotify.Controllers
{
    public class PaginasController : Controller
    {

        private readonly ClonSpotifyContext _context;

        public PaginasController(ClonSpotifyContext context)
        {
            _context = context;
        }
        public IActionResult CrearCuenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCuenta(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                _context.SaveChanges();
                return Redirect("/");
            }
            return NotFound();
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
