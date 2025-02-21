using System;
using System.Collections.Generic;

namespace Clon_Spotify.Models;

public partial class Album
{
    public string AlbumMusica { get; set; } = null!;

    public string TipoCancion { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public string? UrlImage { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
