using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Books;
using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Publishers;

namespace BooksCatalog.Api.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<UpdateBookRequest, Book>();

            CreateMap<Author, AuthorResponse>();
            CreateMap<Genre, GenreResponse>();
            CreateMap<Publisher, PublisherResponse>();
        }
    }
}