using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("/api/genres")]
    public class GenresController : ControllerBase
    {

        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter)
        {
            filter ??= new BaseFilter();
            var genres = await _genresService.GetAll(filter);
            return Ok(genres);
        }

        [HttpGet("{genreId:int}")]
        public async Task<IActionResult> GetGenreById(int genreId)
        {
            try
            {
                var genre = await _genresService.FindById(genreId);
                return Ok(genre);
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGenre(AddNewGenreRequest request)
        {
            try
            {
                await _genresService.AddNewGenre(request);
                return Ok();
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre(UpdateGenreRequest request)
        {
            try
            {
                await _genresService.UpdateGenre(request);
                return Ok();
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{genreId:int}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            try
            {
                await _genresService.RemoveGenre(genreId);
                return Ok();
            }
            catch (GenreNotFoundException)
            {
                return NotFound();
            }
        }
    }
}