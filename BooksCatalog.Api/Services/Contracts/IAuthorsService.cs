using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IAuthorsService
    {
        Task<IEnumerable<AuthorResponse>> GetAll();
        Task<AuthorResponse> FindById(int authorId);
        Task AddAuthor(AddAuthorRequest request);
        Task UpdateAuthor(UpdateAuthorRequest request);
        Task RemoveAuthor(int authorId);
        Task<UploadImageResponse> UploadImage(UploadImageRequest request);
    }
}