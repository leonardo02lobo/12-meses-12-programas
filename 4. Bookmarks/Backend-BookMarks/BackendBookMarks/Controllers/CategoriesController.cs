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
    }
}
