﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using BooksCatalog.Api.Services.Extensions;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Publishers;
using BooksCatalog.Infra.Services.Contracts;
using BooksCatalog.Shared.Guards;
using Microsoft.AspNetCore.Http;

namespace BooksCatalog.Api.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public PublishersService(IPublisherRepository publisherRepository, IMapper mapper, IStorageService storageService)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<IEnumerable<PublisherResponse>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            return publishers.Select(x => _mapper.Map<PublisherResponse>(x));
        }

        public async Task<PublisherResponse> GetPublisherById(int publisherId)
        {
            var publisher = await _publisherRepository.FindByIdAsync(publisherId);
            if (publisher is null) throw new PublisherNotFoundException();

            return _mapper.Map<PublisherResponse>(publisher);
        }

        public async Task AddNewPublisher(AddNewPublisher request)
        {
            var publisher = new Publisher();

            await _publisherRepository.AddAsync(publisher);
            await _publisherRepository.CommitChangesAsync();
        }

        public async Task UpdatePublisher(UpdatePublisherRequest request)
        {
            Guard.Against.NegativeOrZero(request.Id, nameof(request.Id));

            
            var publisher = await _publisherRepository.FindByIdAsync(request.Id);
            if (publisher is null) throw new PublisherNotFoundException();

            var updatedPublisher = _mapper.Map<Publisher>(request);
            await _publisherRepository.UpdateAsync(updatedPublisher);
            await _publisherRepository.CommitChangesAsync();
        }

        public async Task DeletePublisher(int publisherId)
        {
            Guard.Against.NegativeOrZero(publisherId, nameof(publisherId));
            
            var publisher = await _publisherRepository.FindByIdAsync(publisherId);
            if (publisher is null) throw new PublisherNotFoundException();

            await _publisherRepository.RemoveAsync(publisher);
            await _publisherRepository.CommitChangesAsync();
        }

        public async Task<UploadImageResponse> UploadImage(IFormFile file)
        {
            var response = await _storageService.UploadFile(await file.GetBytes(), file.Name, "publisher-images");
            return new UploadImageResponse(response, file.Name);
        }
    }
}