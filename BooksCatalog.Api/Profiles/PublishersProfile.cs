using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Domain.Publisher;

namespace BooksCatalog.Api.Profiles
{
    public class PublishersProfile : Profile
    {
        public PublishersProfile()
        {
            CreateMap<Publisher, PublisherResponse>();
            CreateMap<UpdatePublisherRequest, Publisher>();
            CreateMap<AddNewPublisherRequest, Publisher>();
        }
    }
}