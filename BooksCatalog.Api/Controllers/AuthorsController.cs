using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService) =>
            _authorsService = authorsService;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] BaseFilter filter)
        {
            filter ??= new BaseFilter();
            var authors = _authorsService.GetAll(filter);
            return Ok(authors);
        }

        [HttpGet("{authorId:int}")]
        [AllowAnonymous]
        public IActionResult GetAuthorById(int authorId)
        {
            try
            {
                var author = _authorsService.FindById(authorId);
                return Ok(author);
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AddAuthorRequest request)
        {
            try
            {
                _authorsService.Add(request);
                return Ok();
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorRequest request)
        {
            try
            {
                _authorsService.Update(request);
                return Ok();
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{authorId:int}")]
        public IActionResult RemoveAuthor(int authorId)
        {
            try 
            {
                _authorsService.Remove(authorId);
                return Ok();
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("upload-image")]
        public IActionResult UploadAuthorImage([FromForm] UploadImageRequest request)
        {
            var response = _authorsService.UploadImage(request);
            return Ok(response);
        }
    }
}