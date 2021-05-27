using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService) =>
            _authorsService = authorsService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorsService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            try
            {
                var author = await _authorsService.FindById(authorId);
                return Ok(author);
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest request)
        {
            try
            {
                await _authorsService.AddAuthor(request);
                return Ok();
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request)
        {
            try
            {
                await _authorsService.UpdateAuthor(request);
                return Ok();
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{authorId:int}")]
        public async Task<IActionResult> RemoveAuthor(int authorId)
        {
            try 
            {
                await _authorsService.RemoveAuthor(authorId);
                return Ok();
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadAuthorImage([FromForm] UploadImageRequest request)
        {
            var response = await _authorsService.UploadImage(request);
            return Ok(response);
        }
    }
}