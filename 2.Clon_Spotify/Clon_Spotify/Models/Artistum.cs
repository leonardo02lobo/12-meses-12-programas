using System;
using System.Collections.Generic;

namespace Clon_Spotify.Models;

public partial class Artistum
{
    public int OyentesMensuales { get; set; }

    public string? Descripcion { get; set; }

    public string? Genero { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
