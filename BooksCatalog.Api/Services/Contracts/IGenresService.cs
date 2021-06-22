using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IGenresService
    {
        IEnumerable<GenreResponse> GetAll(BaseFilter baseFilter);
        GenreResponse FindById(int genreId);
        Task AddNewGenre(AddNewGenreRequest request);
        void UpdateGenre(UpdateGenreRequest request);
        void RemoveGenre(int genreId);
    }
}