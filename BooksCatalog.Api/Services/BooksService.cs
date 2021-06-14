using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Api.Models.Events;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using BooksCatalog.Api.Services.Extensions;
using BooksCatalog.Api.Services.Specifications;
using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Books;
using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Publishers;
using BooksCatalog.Infra.Services.Contracts;
using BooksCatalog.Infra.Services.Storage.Contracts;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Api.Services
{
    public class BooksService : IBooksService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IStorageService _storageService;
        private readonly IEventBus _events;

        public BooksService(IBookRepository bookRepository,
            IMapper mapper,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository,
            IPublisherRepository publisherRepository,
            IStorageService storageService,
            IEventBus events)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;
            _storageService = storageService;
            _events = events;
        }

        public async Task<IEnumerable<BookResponse>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => _mapper.Map<BookResponse>(b));
        }

        public async Task<BookResponse> GetBookById(int bookId)
        {
            var book = await _bookRepository.FindByIdAsync(bookId);
            if (book is null) throw new BookNotFoundException();
            return _mapper.Map<BookResponse>(book);
        }

        public async Task AddNewBook(AddNewBookRequest request)
        {
            Guard.Against.NullOrEmpty(request.AuthorIds, nameof(request.AuthorIds));
            Guard.Against.NullOrEmpty(request.GenreIds, nameof(request.GenreIds));
            Guard.Against.NullOrEmpty(request.PublisherIds, nameof(request.PublisherIds));

            var authors = await _authorRepository.GetBySpec(new MultipleIdsSpec<Author>(request.AuthorIds));
            var genres = await _genreRepository.GetBySpec(new MultipleIdsSpec<Genre>(request.GenreIds));
            var publishers = await _publisherRepository.GetBySpec(new MultipleIdsSpec<Publisher>(request.PublisherIds));

            var book = new Book(request.Title, request.ReleaseDate, request.Description,
                request.Isbn, authors, genres, publishers);

            await _bookRepository.AddAsync(book);
            await _bookRepository.CommitChangesAsync();
            await _events.Publish(new BookCreated(book.Id, DateTime.UtcNow));
        }

        public async Task UpdateBook(UpdateBookRequest request)
        {
            var book = await _bookRepository.FindByIdAsync(request.Id);
            if (book is null) throw new BookNotFoundException();

            var updatedBook = _mapper.Map<Book>(request);

            await _bookRepository.UpdateAsync(updatedBook);
        }

        public async Task DeleteBook(int bookId)
        {
            var book = await _bookRepository.FindByIdAsync(bookId);
            if (book is null) throw new BookNotFoundException();

            await _bookRepository.RemoveAsync(book);
        }

        public async Task<UploadImageResponse> UploadImage(UploadImageRequest request)
        {
            Guard.Against.Null(request.Data, nameof(request.Data));
            Guard.Against.NullOrEmpty(request.Name, nameof(request.Name));

            var streamData = await request.Data.GetBytes();
            var uri = await _storageService.UploadFile(streamData, request.Name, "book-covers");
            return new UploadImageResponse(uri, request.Name);
        }
    }
}