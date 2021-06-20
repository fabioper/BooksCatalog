﻿using System;
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
using BooksCatalog.Domain.Authors;
using BooksCatalog.Domain.Authors.Events;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Infra.Services.Storage.Contracts;
using BooksCatalog.Shared.Guards;
using static System.String;

namespace BooksCatalog.Api.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private readonly IMessagePublisher _messagePublisher;

        public AuthorsService(IAuthorRepository authorRepository,
            IMapper mapper, IStorageService storageService, IMessagePublisher messagePublisher)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _storageService = storageService;
            _messagePublisher = messagePublisher;
        }

        public async Task<IEnumerable<AuthorResponse>> GetAll(BaseFilter filter)
        {
            var authors = IsNullOrEmpty(filter.Name)
                ? await _authorRepository.GetAllAsync()
                : await _authorRepository.GetByName(filter.Name);

            return authors.Select(author => _mapper.Map<AuthorResponse>(author));
        }

        public async Task<AuthorResponse> FindById(int authorId)
        {
            var author = await _authorRepository.FindByIdAsync(authorId);
            if (author is null)
                throw new AuthorNotFoundException();
            return _mapper.Map<AuthorResponse>(author);
        }

        public async Task Add(AddAuthorRequest request)
        {
            var author = new Author(request.Name, request.ImageUri, request.BirthDate, request.Biography);

            await _authorRepository.AddAsync(author);
            await _authorRepository.CommitChangesAsync();
            await _messagePublisher.Publish(new AuthorCreated(author.Id, DateTime.UtcNow));
        }

        public async Task Update(UpdateAuthorRequest request)
        {
            Guard.Against.NegativeOrZero(request.Id, nameof(request.Id));

            var author = await _authorRepository.FindByIdAsync(request.Id);
            if (author is null) throw new AuthorNotFoundException();

            var updatedAuthor = _mapper.Map<Author>(request);

            await _authorRepository.UpdateAsync(updatedAuthor);
            await _authorRepository.CommitChangesAsync();
        }

        public async Task Remove(int authorId)
        {
            Guard.Against.NegativeOrZero(authorId, nameof(authorId));

            var author = await _authorRepository.FindByIdAsync(authorId);
            if (author is null) throw new AuthorNotFoundException();

            await _authorRepository.RemoveAsync(author);
            await _authorRepository.CommitChangesAsync();
        }

        public async Task<UploadImageResponse> UploadImage(UploadImageRequest request)
        {
            var data = await request.Data.GetBytes();
            var response = await _storageService.UploadFile(data, request.Name, "authors-images");
            return new UploadImageResponse(response, request.Name);
        }
    }
}