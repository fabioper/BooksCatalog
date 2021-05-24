using AutoMapper;
using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Books;
using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Publishers;
using BooksCatalog.Shared.Models.Requests;
using BooksCatalog.Shared.Models.Responses;

namespace BooksCatalog.Application.Profiles
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