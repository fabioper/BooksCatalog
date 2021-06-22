using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using BooksCatalog.Api.Services.Extensions;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Domain.Publishers;
using BooksCatalog.Domain.Publishers.Events;
using BooksCatalog.Infra.Services.Storage.Contracts;
using BooksCatalog.Shared.Guards;
using Microsoft.AspNetCore.Http;

namespace BooksCatalog.Api.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly IMessagePublisher _messagePublisher;

        public PublishersService(IPublisherRepository publisherRepository,
            IMapper mapper, IStorageService storageService, IMessagePublisher messagePublisher)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _storageService = storageService;
            _messagePublisher = messagePublisher;
        }

        public IEnumerable<PublisherResponse> GetAllPublishers(BaseFilter filter)
        {
            var publishers = string.IsNullOrEmpty(filter.Name)
                ? _publisherRepository.GetAllAsync()
                : _publisherRepository.GetByName(filter.Name);
            
            return publishers.Select(x => _mapper.Map<PublisherResponse>(x));
        }

        public PublisherResponse GetPublisherById(int publisherId)
        {
            var publisher = _publisherRepository.FindByIdAsync(publisherId);
            if (publisher is null) throw new PublisherNotFoundException();

            return _mapper.Map<PublisherResponse>(publisher);
        }

        public async Task AddNewPublisher(AddNewPublisherRequest request)
        {
            var publisher = new Publisher(request.Name);

            _publisherRepository.AddAsync(publisher);
            _publisherRepository.CommitChangesAsync();
            await _messagePublisher.Publish(new PublisherCreated(publisher.Id, DateTime.UtcNow));
        }

        public void UpdatePublisher(UpdatePublisherRequest request)
        {
            Guard.Against.NegativeOrZero(request.Id, nameof(request.Id));

            
            var publisher = _publisherRepository.FindByIdAsync(request.Id);
            if (publisher is null) throw new PublisherNotFoundException();

            var updatedPublisher = _mapper.Map<Publisher>(request);
            _publisherRepository.UpdateAsync(updatedPublisher);
            _publisherRepository.CommitChangesAsync();
        }

        public void DeletePublisher(int publisherId)
        {
            Guard.Against.NegativeOrZero(publisherId, nameof(publisherId));
            
            var publisher = _publisherRepository.FindByIdAsync(publisherId);
            if (publisher is null) throw new PublisherNotFoundException();

            _publisherRepository.RemoveAsync(publisher);
            _publisherRepository.CommitChangesAsync();
        }

        public async Task<UploadImageResponse> UploadImage(IFormFile file)
        {
            var response = await _storageService.UploadFile(await file.GetBytes(), file.Name, "publisher-images");
            return new UploadImageResponse(response, file.Name);
        }
    }
}