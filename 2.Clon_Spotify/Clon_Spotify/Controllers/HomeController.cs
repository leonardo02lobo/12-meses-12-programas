using System.Diagnostics;
using Clon_Spotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clon_Spotify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClonSpotifyContext _context;

        public HomeController(ClonSpotifyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ListaAlbum = _context.Albums.ToList();
            ViewBag.ListaArtistas = _context.Usuarios.ToList();
            ViewBag.band = true;
            return View();
        }
        [HttpPost]
        public IActionResult Index(bool band)
        {
            ViewBag.ListaAlbum = _context.Albums.ToList();
            ViewBag.band = false;
            return View();
        }
        public IActionResult Listado()
        {
            return View();
        }
    }
}
