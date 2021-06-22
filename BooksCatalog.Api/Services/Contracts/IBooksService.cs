using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IBooksService
    {
        IEnumerable<BookResponse> GetBooks();
        BookResponse GetBookById(int bookId);
        Task AddNewBook(AddNewBookRequest request);
        void UpdateBook(UpdateBookRequest request);
        Task DeleteBook(int bookId);
        Task<UploadImageResponse> UploadImage(UploadImageRequest request);
    }
}