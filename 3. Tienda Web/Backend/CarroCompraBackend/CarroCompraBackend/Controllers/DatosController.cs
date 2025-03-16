using CarroCompraBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarroCompraBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly CarritoCompraContext _context;

        public DatosController(CarritoCompraContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Producto")]
        public IActionResult GetProducto()
        {
            return Ok(_context.Productos);
        }

        [HttpGet]
        [Route("Buscar")]
        public IActionResult GetBuscar(string nombreProducto)
        {

            return Ok(_context.Productos.Where(b => b.Titulo.Contains(nombreProducto)).ToList());
        }
    }
}
