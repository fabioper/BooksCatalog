using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IGenresService
    {
        Task<IEnumerable<GenreResponse>> GetAll(BaseFilter baseFilter);
        Task<GenreResponse> FindById(int genreId);
        Task AddNewGenre(AddNewGenreRequest request);
        Task UpdateGenre(UpdateGenreRequest request);
        Task RemoveGenre(int genreId);
    }
}