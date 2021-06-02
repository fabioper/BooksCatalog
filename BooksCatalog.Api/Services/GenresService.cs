using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Api.Services.Contracts;

namespace BooksCatalog.Api.Services
{
    public class GenresService : IGenresService
    {
        public Task<IEnumerable<GenreResponse>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<GenreResponse> FindById(int genreId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddNewGenre(AddNewGenreRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGenre(UpdateGenreRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveGenre(int genreId)
        {
            throw new System.NotImplementedException();
        }
    }
}