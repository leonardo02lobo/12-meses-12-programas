using Clon_Spotify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clon_Spotify.Controllers
{
    public class ArtistaController : Controller
    {
        private readonly ClonSpotifyContext _context;

        public ArtistaController(ClonSpotifyContext context)
        {
            _context = context;
        }
        public IActionResult GuardarArtista(string nombreArtista)
        {
            var datosArtista = _context.Usuarios.FirstOrDefault(d => d.NombreUsuario == nombreArtista);
            var Id = User.Claims.FirstOrDefault(d => d.Type == ClaimTypes.Dns)?.Value;
            var logo = datosArtista?.FotoPerfil;

            if (datosArtista != null && Id != null)
            {
                Biblioteca nuevoArtista = new Biblioteca
                {
                    AlbumMusica = datosArtista.NombreUsuario,
                    IdUsuario = datosArtista.IdUsuario,
                    NombreUsuario = "",
                    Tipo = "Artista",
                    Id = int.Parse(Id),
                    Logo = logo ?? string.Empty
                };

                _context.Bibliotecas.Add(nuevoArtista);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EliminarArtista(string nombreArtista)
        {
            var datosAlbum = _context.Usuarios.FirstOrDefault(d => d.NombreUsuario == nombreArtista);
            var Id = User.Claims.FirstOrDefault(d => d.Type == ClaimTypes.Dns)?.Value;
            var nombreUsuario = User.Identity?.Name;
            var logo = datosAlbum?.FotoPerfil;

            if (datosAlbum != null && Id != null && nombreUsuario != null)
            {
                var playList = _context.Bibliotecas.FirstOrDefault(b => b.Id == int.Parse(Id) && b.NombreUsuario == nombreUsuario);

                if (playList != null)
                {
                    _context.Bibliotecas.Remove(playList);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
