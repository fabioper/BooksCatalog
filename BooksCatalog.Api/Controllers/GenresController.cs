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
    [Route("/api/genres")]
    [Authorize]
    public class GenresController : ControllerBase
    {

        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] BaseFilter filter)
        {
            filter ??= new BaseFilter();
            var genres = _genresService.GetAll(filter);
            return Ok(genres);
        }

        [HttpGet("{genreId:int}")]
        [AllowAnonymous]
        public IActionResult GetGenreById(int genreId)
        {
            try
            {
                var genre = _genresService.FindById(genreId);
                return Ok(genre);
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddNewGenre(AddNewGenreRequest request)
        {
            try
            {
                _genresService.AddNewGenre(request);
                return Ok();
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult UpdateGenre(UpdateGenreRequest request)
        {
            try
            {
                _genresService.UpdateGenre(request);
                return Ok();
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{genreId:int}")]
        public IActionResult DeleteGenre(int genreId)
        {
            try
            {
                _genresService.RemoveGenre(genreId);
                return Ok();
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }
    }
}