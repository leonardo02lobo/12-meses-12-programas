using API_JUEGOS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace API_JUEGOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        private readonly ApiJuegoContext _context;

        public ApiGameController(ApiJuegoContext context)
        {
            _context = context;
        }

        public List<Game> Get()
            => _context.Games.ToList();
    }
}
