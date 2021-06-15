using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using BooksCatalog.Domain;
using BooksCatalog.Domain.Genre;
using BooksCatalog.Domain.Genre.Events;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;

namespace BooksCatalog.Api.Services
{
    public class GenresService : IGenresService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly IMessagePublisher _messagePublisher;

        public GenresService(IGenreRepository genreRepository, IMapper mapper, IMessagePublisher messagePublisher)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }

        public async Task<IEnumerable<GenreResponse>> GetAll()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.Select(genre => _mapper.Map<GenreResponse>(genre));
        }

        public async Task<GenreResponse> FindById(int genreId)
        {
            var genre = await _genreRepository.FindByIdAsync(genreId);
            if (genre is null) throw new GenreNotFoundException();
            return _mapper.Map<GenreResponse>(genre);
        }

        public async Task AddNewGenre(AddNewGenreRequest request)
        {
            var genre = new Genre();

            await _genreRepository.AddAsync(genre);
            await _genreRepository.CommitChangesAsync();
            await _messagePublisher.Publish(new GenreCreated(genre.Id, DateTime.UtcNow));
        }

        public async Task UpdateGenre(UpdateGenreRequest request)
        {
            var genre = await _genreRepository.FindByIdAsync(request.Id);
            if (genre is null) throw new GenreNotFoundException();

            var updatedGenre = _mapper.Map<Genre>(genre);
            
            await _genreRepository.UpdateAsync(updatedGenre);
            await _genreRepository.CommitChangesAsync();
        }

        public async Task RemoveGenre(int genreId)
        {
            var genre = await _genreRepository.FindByIdAsync(genreId);
            if (genre is null) throw new GenreNotFoundException();

            await _genreRepository.RemoveAsync(genre);
            await _genreRepository.CommitChangesAsync();
        }
    }
}