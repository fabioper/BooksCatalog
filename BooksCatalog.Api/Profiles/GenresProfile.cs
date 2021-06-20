using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Domain.Genre;

namespace BooksCatalog.Api.Profiles
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<Genre, GenreResponse>();
            CreateMap<UpdateGenreRequest, Genre>();
            CreateMap<AddNewGenreRequest, Genre>();
        }
    }
}