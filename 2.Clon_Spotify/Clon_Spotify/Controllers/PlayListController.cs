using Clon_Spotify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clon_Spotify.Controllers
{
    public class PlayListController : Controller
    {
        private readonly ClonSpotifyContext _context;

        public PlayListController(ClonSpotifyContext context)
        {
            _context = context;
        }
        public IActionResult GuardarPlayList(string nombreAlbum)
        {
            var datosAlbum = _context.Albums.FirstOrDefault(d => d.AlbumMusica == nombreAlbum);
            var Id = User.Claims.FirstOrDefault(d => d.Type == ClaimTypes.Dns)?.Value;
            var nombreUsuario = User.Identity?.Name;
            var logo = datosAlbum?.UrlImage;

            if (datosAlbum != null && Id != null && nombreUsuario != null)
            {
                Biblioteca nuevaPlaylist = new Biblioteca
                {
                    AlbumMusica = datosAlbum.AlbumMusica,
                    IdUsuario = datosAlbum.IdUsuario,
                    NombreUsuario = nombreUsuario,
                    Tipo = "Album",
                    Id = int.Parse(Id),
                    Logo = logo ?? string.Empty
                };

                _context.Bibliotecas.Add(nuevaPlaylist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EliminarPlayList(string nombreAlbum)
        {
            var datosAlbum = _context.Albums.FirstOrDefault(d => d.AlbumMusica == nombreAlbum);
            var Id = User.Claims.FirstOrDefault(d => d.Type == ClaimTypes.Dns)?.Value;
            var nombreUsuario = User.Identity?.Name;
            var logo = datosAlbum?.UrlImage;

            if (datosAlbum != null && Id != null && nombreUsuario != null)
            {
                var playList = _context.Bibliotecas.FirstOrDefault(b => b.AlbumMusica == nombreAlbum && b.Id == int.Parse(Id) && b.NombreUsuario == nombreUsuario);

                if(playList != null)
                {
                    _context.Bibliotecas.Remove(playList);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
