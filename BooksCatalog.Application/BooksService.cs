using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Books;
using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Publishers;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Models.Requests;
using BooksCatalog.Shared.Models.Responses;

namespace BooksCatalog.Application
{
    public class BooksService : IBooksService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;

        public BooksService(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository,
            IGenreRepository genreRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<BookResponse>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => _mapper.Map<BookResponse>(b));
        }

        public async Task<BookResponse> GetBookById(int bookId)
        {
            var book = await _bookRepository.FindByIdAsync(bookId);
            return _mapper.Map<BookResponse>(book);
        }

        public async Task AddNewBook(AddNewBookRequest request)
        {
            Guard.Against.NullOrEmpty(request.AuthorIds, nameof(request.AuthorIds));
            Guard.Against.NullOrEmpty(request.GenreIds, nameof(request.GenreIds));
            Guard.Against.NullOrEmpty(request.PublisherIds, nameof(request.PublisherIds));

            var authors = await _authorRepository.GetBySpec(new MultipleIds<Author>(request.AuthorIds));
            var genres = await _genreRepository.GetBySpec(new MultipleIds<Genre>(request.GenreIds));
            var publishers = await _publisherRepository.GetBySpec(new MultipleIds<Publisher>(request.PublisherIds));

            var book = new Book(request.Title, request.ReleaseDate, request.Description,
                request.Isbn, authors, genres, publishers);

            await _bookRepository.AddAsync(book);
            await _bookRepository.CommitChangesAsync();
        }

        public async Task UpdateBook(UpdateBookRequest request)
        {
            var book = await _bookRepository.FindByIdAsync(request.Id);
            if (book is null) throw new ArgumentException();

            var updatedBook = _mapper.Map<Book>(request);

            await _bookRepository.UpdateAsync(updatedBook);
        }

        public async Task DeleteBook(int bookId)
        {
            var book = await _bookRepository.FindByIdAsync(bookId);
            if (book is null) throw new ArgumentException();

            await _bookRepository.RemoveAsync(book.Id);
        }
    }
}