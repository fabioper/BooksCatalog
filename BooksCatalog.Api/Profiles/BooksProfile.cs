using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Core;
using BooksCatalog.Core.Books;
using BooksCatalog.Core.Genre;
using BooksCatalog.Core.Publisher;

namespace BooksCatalog.Api.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<UpdateBookRequest, Book>();
            
            CreateMap<Genre, GenreResponse>();

            CreateMap<Publisher, PublisherResponse>();
        }
    }
}