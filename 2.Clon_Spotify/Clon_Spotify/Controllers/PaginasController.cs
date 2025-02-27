using Clon_Spotify.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                return RedirectToAction(nameof(IniciarSesion));
            }
            return NotFound();
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Correo == usuario.Correo && u.Contrasenia == usuario.Contrasenia);
            if (user != null)
            {
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,user.Correo),
                            new Claim(ClaimTypes.Name,user.NombreUsuario),
                            new Claim(ClaimTypes.Dns,user.IdUsuario.ToString()),
                            new Claim("Password",user.Contrasenia),
                            new Claim("Seguidores",user.Seguidores.ToString()),
                            new Claim("Seguidos",user.Seguidos.ToString()),
                            new Claim("Verificacion",user.Verificacion.ToString()),
                            new Claim("FotoPerfil",user.FotoPerfil ?? string.Empty),
                            new Claim("FotoFondo",user.FotoFondo ?? string.Empty),
                            new Claim("Pais",user.Pais ?? string.Empty),
                            new Claim("Premium",user.Premium?.ToString() ?? string.Empty)
                        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return Redirect("/");
            }
            return IniciarSesion();
        }

        public IActionResult RestablecerContrasenia()
        {
            return View();
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
