using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_JUEGOS.Models;

public partial class Game
{
    
    public int Id { get; set; }

    public string NombreJuego { get; set; } = null!;

    public string CategoriaJuego { get; set; } = null!;

    public int AnioLanzamiento { get; set; }

    public int PrecioLanzamiento { get; set; }
}
