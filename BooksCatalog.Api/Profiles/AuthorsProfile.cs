using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Domain.Authors;

namespace BooksCatalog.Api.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorResponse>();
            CreateMap<UpdateAuthorRequest, Author>();
        }
    }
}