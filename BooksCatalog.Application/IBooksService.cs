﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Shared.Models.Requests;
using BooksCatalog.Shared.Models.Responses;

namespace BooksCatalog.Application
{
    public interface IBooksService
    {
        Task<IEnumerable<BookResponse>> GetBooks();
        Task<BookResponse> GetBookById(int bookId);
        Task AddNewBook(AddNewBookRequest request);
        Task UpdateBook(UpdateBookRequest request);
        Task DeleteBook(int bookId);
    }
}