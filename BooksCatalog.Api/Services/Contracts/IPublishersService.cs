﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using Microsoft.AspNetCore.Http;

namespace BooksCatalog.Api.Services.Contracts
{
    public interface IPublishersService
    {
        Task<IEnumerable<PublisherResponse>> GetAllPublishers();
        Task<PublisherResponse> GetPublisherById(int publisherId);
        Task AddNewPublisher(AddNewPublisher request);
        Task UpdatePublisher(UpdatePublisherRequest request);

        Task DeletePublisher(int publisherId);
        Task<UploadImageResponse> UploadImage(IFormFile file);
    }
}