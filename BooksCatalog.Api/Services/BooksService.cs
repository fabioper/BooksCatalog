using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Models.Responses;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using BooksCatalog.Api.Services.Extensions;
using BooksCatalog.Api.Services.Specifications;
using BooksCatalog.Domain.Authors;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Books.Events;
using BooksCatalog.Domain.Genres;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Domain.Publishers;
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
        private readonly IMessagePublisher _messagePublisher;

        public BooksService(IBookRepository bookRepository,
            IMapper mapper,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository,
            IPublisherRepository publisherRepository,
            IStorageService storageService,
            IMessagePublisher messagePublisher)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;
            _storageService = storageService;
            _messagePublisher = messagePublisher;
        }

        public IEnumerable<BookResponse> GetBooks()
        {
            var books = _bookRepository.GetAllAsync();
            return books.Select(b => _mapper.Map<BookResponse>(b));
        }

        public BookResponse GetBookById(int bookId)
        {
            var book = _bookRepository.FindByIdAsync(bookId);
            if (book is null) throw new BookNotFoundException();
            return _mapper.Map<BookResponse>(book);
        }

        public async Task AddNewBook(AddNewBookRequest request)
        {
            Guard.Against.NullOrEmpty(request.AuthorIds, nameof(request.AuthorIds));
            Guard.Against.NullOrEmpty(request.GenreIds, nameof(request.GenreIds));
            Guard.Against.NullOrEmpty(request.PublisherIds, nameof(request.PublisherIds));

            var authors = _authorRepository.GetBy(new MultipleIdsSpec<Author>(request.AuthorIds));
            var genres = _genreRepository.GetBy(new MultipleIdsSpec<Genre>(request.GenreIds));
            var publishers = _publisherRepository.GetBy(new MultipleIdsSpec<Publisher>(request.PublisherIds));

            var book = new Book(
                request.Title,
                request.ReleaseDate,
                request.Description,
                request.CoverUri,
                authors,
                genres,
                publishers
            );

            _bookRepository.UpdateAsync(book);
            _bookRepository.CommitChangesAsync();
            await _messagePublisher.Publish(new BookCreated(book.Id, DateTime.UtcNow));
        }

        public void UpdateBook(UpdateBookRequest request)
        {
            var book = _bookRepository.FindByIdAsync(request.Id);
            if (book is null) throw new BookNotFoundException();

            var updatedBook = _mapper.Map<Book>(request);

            _bookRepository.UpdateAsync(updatedBook);
            _bookRepository.CommitChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var book = _bookRepository.FindByIdAsync(bookId);
            if (book is null) throw new BookNotFoundException();

            _bookRepository.RemoveAsync(book);
            _bookRepository.CommitChangesAsync();
            await _messagePublisher.Publish(new BookRemoved(book.Id));
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