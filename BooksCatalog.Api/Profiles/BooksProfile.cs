using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Domain;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Genre;
using BooksCatalog.Domain.Publisher;

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