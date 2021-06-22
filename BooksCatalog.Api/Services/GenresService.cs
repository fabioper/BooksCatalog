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
using BooksCatalog.Domain.Genres;
using BooksCatalog.Domain.Genres.Events;
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

        public IEnumerable<GenreResponse> GetAll(BaseFilter baseFilter)
        {
            var genres = string.IsNullOrEmpty(baseFilter.Name)
                ? _genreRepository.GetAllAsync()
                : _genreRepository.GetByName(baseFilter.Name);
            
            return genres.Select(genre => _mapper.Map<GenreResponse>(genre));
        }

        public GenreResponse FindById(int genreId)
        {
            var genre = _genreRepository.FindByIdAsync(genreId);
            if (genre is null) throw new GenreNotFoundException();
            return _mapper.Map<GenreResponse>(genre);
        }

        public async Task AddNewGenre(AddNewGenreRequest request)
        {
            var genre = new Genre(request.Name);

            _genreRepository.AddAsync(genre);
            _genreRepository.CommitChangesAsync();
            await _messagePublisher.Publish(new GenreCreated(genre.Id, DateTime.UtcNow));
        }

        public void UpdateGenre(UpdateGenreRequest request)
        {
            var genre = _genreRepository.FindByIdAsync(request.Id);
            if (genre is null) throw new GenreNotFoundException();

            var updatedGenre = _mapper.Map<Genre>(request);
            
            _genreRepository.UpdateAsync(updatedGenre);
            _genreRepository.CommitChangesAsync();
        }

        public void RemoveGenre(int genreId)
        {
            var genre = _genreRepository.FindByIdAsync(genreId);
            if (genre is null) throw new GenreNotFoundException();

            _genreRepository.RemoveAsync(genre);
            _genreRepository.CommitChangesAsync();
        }
    }
}