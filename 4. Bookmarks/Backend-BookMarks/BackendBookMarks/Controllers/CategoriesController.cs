using BackendBookMarks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBookMarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BookMarkContext _bookmark;

        public CategoriesController(BookMarkContext bookmark)
        {
            _bookmark = bookmark;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_bookmark.Categories);
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            try
            {
                if (category == null || string.IsNullOrEmpty(category.Name))
                {
                    return BadRequest(new { message = "Error al recibir los datos" });
                }
                if (_bookmark.Categories.Any(c => c.Name == category.Name)) 
                {
                    return BadRequest(new { message = "ya Existe esta Categoria" });
                }
                _bookmark.Categories.Add(category);
                await _bookmark.SaveChangesAsync();
                return Ok(new { message = "Agregaste una nueva Categoria" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);

                return StatusCode(500, new { mensaje = "Ocurrió un error interno", error = e.InnerException?.Message ?? e.Message });
            }
        }
    }
}
