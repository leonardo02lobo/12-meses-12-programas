using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Clon_Spotify.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listado()
        {
            return View();
        }
    }
}
