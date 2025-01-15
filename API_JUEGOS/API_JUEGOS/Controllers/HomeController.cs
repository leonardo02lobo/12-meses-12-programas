using System.Diagnostics;
using API_JUEGOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_JUEGOS.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApiJuegoContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public HomeController(ApiJuegoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Games.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                var games = new Game()
                {
                    NombreJuego = game.NombreJuego,
                    CategoriaJuego = game.CategoriaJuego,
                    AnioLanzamiento = game.AnioLanzamiento,
                    PrecioLanzamiento = game.PrecioLanzamiento
                };
                _context.Add(games);
                _context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Games.Where(m => m.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public IActionResult Details(int id)
        {
            return View(_context.Games.Where(m=>m.Id == id).FirstOrDefault());
        }

        public IActionResult Delete(int id)
        {
            return View(_context.Games.Where(m => m.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(Game game)
        {
            _context.Remove(game);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
