using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<BookResponse>> GetBooks();
        Task<BookResponse> GetBookById(int bookId);
        Task AddNewBook(AddNewBookRequest request);
        Task UpdateBook(UpdateBookRequest request);
        Task DeleteBook(int bookId);
        Task<UploadImageResponse> UploadImage(UploadImageRequest request);
    }
}