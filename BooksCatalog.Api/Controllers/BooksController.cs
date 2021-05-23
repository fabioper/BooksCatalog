using System.Threading.Tasks;
using BooksCatalog.Application;
using BooksCatalog.Application.Interfaces;
using BooksCatalog.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("/{bookId:int}")]
        public async Task<IActionResult> GetBook([FromRoute] int bookId)
        {
            var book = await _booksService.GetBookById(bookId);
            if (book is null) return NotFound();
            return Ok();
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
            await _booksService.UpdateBook(request);
            return Ok();
        }

        [HttpDelete("/{bookId:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            await _booksService.DeleteBook(bookId);
            return Ok();
        }
    }
}