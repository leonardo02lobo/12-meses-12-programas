using CarroCompraBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CarroCompraBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly CarritoCompraContext _context;

        public CRUDController(CarritoCompraContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Descripcion) || string.IsNullOrWhiteSpace(request.Imagen))
            {
                return BadRequest(new { message = "Todos los campos son requeridos." });
            }

            var producto = new Producto
            {
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                UrlImage = request.Imagen,
                Precio = request.Precio
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Producto agregado correctamente." });
        }
    }
}

public class ProductoRequest
{
    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = null!;

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = null!;

    [JsonPropertyName("imagen")]
    public string Imagen { get; set; } = null!;
    [JsonPropertyName("precio")]
    public decimal Precio { get; set; } = 0!;
}