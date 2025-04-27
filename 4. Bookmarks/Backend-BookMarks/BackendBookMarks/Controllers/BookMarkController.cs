using BackendBookMarks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBookMarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookMarkController : ControllerBase
    {

        private readonly BookMarkContext _bookMark;

        public BookMarkController(BookMarkContext bookMark)
        {
            _bookMark = bookMark;
        }

        [HttpGet]
        [Route("GetBookMarks")]
        public IActionResult GetBookMark()
        {
            var bookMarkWithCategories = _bookMark.Bookmarks
                .Join(_bookMark.Categories,
                bookmark => bookmark.CategoryId,
                category => category.Id,
                (bookmark, category) => new
                {
                    bookmark.Id,
                    bookmark.Title,
                    bookmark.Url,
                    bookmark.Description,
                    CategoryName = category.Name,
                    bookmark.CreatedAt
                });
            if (bookMarkWithCategories == null)
            {
                return NotFound();
            }
            return Ok(bookMarkWithCategories);
        }

        [HttpGet]
        [Route("FindSearchBookMark")]
        public IActionResult GetFindBookMark(string Title)
        {
            if (Title == null || Title == "")
            {
                return NotFound();
            }
            var bookmark = _bookMark.Bookmarks.Join(
                _bookMark.Categories, bookmark => bookmark.CategoryId,
                category => category.Id,
                (bookmark, category) => new
                {
                    bookmark.Id,
                    bookmark.Title,
                    bookmark.Url,
                    bookmark.Description,
                    CategoryName = category.Name,
                    bookmark.CreatedAt
                }).Where(n => n.Title.Contains(Title)).ToList();
            return Ok(bookmark);
        }

        [HttpGet]
        [Route("FindId")]
        public IActionResult GeTBookMarkID(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var bookMark = _bookMark.Bookmarks.Join(
                _bookMark.Categories, bookmark => bookmark.CategoryId,
                category => category.Id,
                (bookmark, category) => new
                {
                    bookmark.Id,
                    bookmark.Title,
                    bookmark.Url,
                    bookmark.Description,
                    CategoryName = category.Name,
                    bookmark.CreatedAt
                }).First(n => n.Id == id);
            return Ok(bookMark);
        }

        [HttpGet]
        [Route("FindByCategory")]
        public IActionResult GetByCategories(string categories)
        {
            try
            {
                if (string.IsNullOrEmpty(categories))
                {
                    return NotFound();
                }

                var bookmark = _bookMark.Bookmarks.Join(
                _bookMark.Categories, bookmark => bookmark.CategoryId,
                category => category.Id,
                (bookmark, category) => new
                {
                    bookmark.Id,
                    bookmark.Title,
                    bookmark.Url,
                    bookmark.Description,
                    CategoryName = category.Name,
                    bookmark.CreatedAt
                }).Where(n => n.CategoryName == categories).ToList();
                return Ok(bookmark);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message}");
            }
        }

        [HttpPost]
        [Route("AddBookMark")]
        public async Task<IActionResult> CreateBookMark([FromBody] Bookmark bookmark)
        {
            try
            {
                if (bookmark == null || string.IsNullOrEmpty(bookmark.Title))
                {
                    return BadRequest(new { mensaje = "Datos no válidos" });
                }
                _bookMark.Bookmarks.Add(bookmark);
                await _bookMark.SaveChangesAsync();

                return Ok(new { mensaje = "Datos recibidos correctamente", id = bookmark.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);

                return StatusCode(500, new { mensaje = "Ocurrió un error interno", error = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}
