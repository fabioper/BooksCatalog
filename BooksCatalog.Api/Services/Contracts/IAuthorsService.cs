using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IAuthorsService
    {
        IEnumerable<AuthorResponse> GetAll(BaseFilter filter);
        AuthorResponse FindById(int authorId);
        Task Add(AddAuthorRequest request);
        void Update(UpdateAuthorRequest request);
        void Remove(int authorId);
        Task<UploadImageResponse> UploadImage(UploadImageRequest request);
    }
}