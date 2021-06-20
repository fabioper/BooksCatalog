using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Domain.Books;

namespace BooksCatalog.Api.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<UpdateBookRequest, Book>();
        }
    }
}