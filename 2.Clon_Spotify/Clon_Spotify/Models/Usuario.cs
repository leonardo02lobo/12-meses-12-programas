using System;
using System.Collections.Generic;

namespace Clon_Spotify.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int Seguidores { get; set; }

    public int Seguidos { get; set; }

    public bool Verificacion { get; set; }

    public string? FotoPerfil { get; set; }

    public string? FotoFondo { get; set; }

    public string? Pais { get; set; }

    public virtual Premium? Premium { get; set; }
}
