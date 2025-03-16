using System;
using System.Collections.Generic;

namespace CarroCompraBackend.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string UrlImage { get; set; } = null!;

    public decimal? Precio { get; set; }
}
