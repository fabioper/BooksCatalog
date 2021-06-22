using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using Microsoft.AspNetCore.Http;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IPublishersService
    {
        IEnumerable<PublisherResponse> GetAllPublishers(BaseFilter filter);
        PublisherResponse GetPublisherById(int publisherId);
        Task AddNewPublisher(AddNewPublisherRequest request);
        void UpdatePublisher(UpdatePublisherRequest request);

        void DeletePublisher(int publisherId);
        Task<UploadImageResponse> UploadImage(IFormFile file);
    }
}