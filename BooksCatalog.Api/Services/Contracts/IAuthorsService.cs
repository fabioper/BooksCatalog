using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IAuthorsService
    {
        Task<IEnumerable<AuthorResponse>> GetAll(BaseFilter filter);
        Task<AuthorResponse> FindById(int authorId);
        Task Add(AddAuthorRequest request);
        Task Update(UpdateAuthorRequest request);
        Task Remove(int authorId);
        Task<UploadImageResponse> UploadImage(UploadImageRequest request);
    }
}