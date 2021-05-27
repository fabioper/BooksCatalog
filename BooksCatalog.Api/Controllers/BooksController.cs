using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetBook([FromRoute] int bookId)
        {
            try
            {
                var book = await _booksService.GetBookById(bookId);
                if (book is null) return NotFound();
                return Ok();
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
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            try
            {
                await _booksService.UpdateBook(request);
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