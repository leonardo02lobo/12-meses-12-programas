using Clon_Spotify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clon_Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ClonSpotifyContext _context;

        public ApiController(ClonSpotifyContext context)
        {
            _context = context; 
        }

        [Route("Usuarios")]
        [HttpGet]
        public IActionResult getUsuario()
        {
            return Ok(_context.Usuarios);
        }

        [Route("Album")]
        [HttpGet]
        public IActionResult getAlbum()
        {
            return Ok(_context.Albums);
        }

        [Route("Artista")]
        [HttpGet]
        public IActionResult getArtista()
        {
            return Ok(_context.Artista);
        }

        [Route("Cancion")]
        [HttpGet]
        public IActionResult getCancion()
        {
            return Ok(_context.Cancions);
        }

        [Route("Artista/Buscar")]
        [HttpGet]
        public IActionResult getBuscarArtista(string nombreUsuario)
        {
            return Ok(_context.Usuarios.FirstOrDefault(m => m.NombreUsuario == nombreUsuario));
        }
    }
}
