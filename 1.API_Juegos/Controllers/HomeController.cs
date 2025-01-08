using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _1.API_Juegos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(int a)
    {
        return View();
    }
}
