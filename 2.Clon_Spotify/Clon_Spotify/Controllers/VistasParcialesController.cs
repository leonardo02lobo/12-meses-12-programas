using Clon_Spotify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clon_Spotify.Controllers
{
    public class VistasParcialesController : Controller
    {
        private readonly ClonSpotifyContext clonSpotifyContext;

        public VistasParcialesController(ClonSpotifyContext clonSpotifyContext)
        {
            this.clonSpotifyContext = clonSpotifyContext;
        }

        public IActionResult PlayList(string nombreAlbum)
        {
            Album? album = clonSpotifyContext.Albums.FirstOrDefault(m => m.AlbumMusica == nombreAlbum);
            if(album != null)
            {
                Usuario? usuario = clonSpotifyContext.Usuarios.FirstOrDefault(m=> m.IdUsuario == album.IdUsuario);

                if (usuario != null)
                {
                    ViewBag.Usuario = usuario;
                    return View(clonSpotifyContext.Cancions.Where(m => m.AlbumMusica == nombreAlbum).ToList());
                }
            }
            return NotFound();
        }

        public IActionResult VerMasPlayList(string texto)
        {
            ViewBag.Texto = texto;
            return View(clonSpotifyContext.Albums.ToList());
        }
        public IActionResult VerArtista(int id)
        {
            var usuarioArtista = clonSpotifyContext.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            var datosArtista = clonSpotifyContext.Artista.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioArtista == null)
            {
                return NotFound();
            }
            ViewBag.Artista = usuarioArtista;
            ViewBag.DatosExtra = datosArtista;
            return View(clonSpotifyContext.Albums.Where(m => m.IdUsuario == id).ToList());
        }
    }
}
