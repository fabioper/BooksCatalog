using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBooks()
        {
            var books = _booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{bookId:int}")]
        [AllowAnonymous]
        public IActionResult GetBook([FromRoute] int bookId)
        {
            try
            {
                var book = _booksService.GetBookById(bookId);
                return Ok(book);
            }
            catch (BookNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] AddNewBookRequest request)
        {
            await _booksService.AddNewBook(request);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateBook([FromBody] UpdateBookRequest request)
        {
            try
            {
                _booksService.UpdateBook(request);
                return Ok();
            }
            catch (BookNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{bookId:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            try
            {
                await _booksService.DeleteBook(bookId);
                return Ok();
            }
            catch (BookNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("upload-cover")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request)
        {
            var response = await _booksService.UploadImage(request);
            return Ok(response);
        }
    }
}