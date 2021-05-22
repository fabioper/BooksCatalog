using System.Threading.Tasks;
using BooksCatalog.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok();
        }

        [HttpGet("/{bookId:int}")]
        public async Task<IActionResult> GetBook([FromRoute] int bookId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] AddNewBookRequest request)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            return Ok();
        }

        [HttpDelete("/{bookId:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            return Ok();
        }
    }
}