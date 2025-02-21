using System;
using System.Collections.Generic;

namespace Clon_Spotify.Models;

public partial class Cancion
{
    public string UrlImage { get; set; } = null!;

    public string NombreMusica { get; set; } = null!;

    public string AlbumMusica { get; set; } = null!;

    public int Anio { get; set; }

    public string TiempoMusica { get; set; } = null!;

    public int NumeroReproducciones { get; set; }
}
