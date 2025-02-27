using System;
using System.Collections.Generic;

namespace Clon_Spotify.Models;

public partial class Biblioteca
{
    public string AlbumMusica { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int Id { get; set; }

    public string Logo { get; set; } = null!;

    public int BibliotecaId { get; set; }
}
