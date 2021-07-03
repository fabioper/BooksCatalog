using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using BooksCatalog.Domain.Authors;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Books.Events;
using BooksCatalog.Domain.Genres;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Domain.Publishers;
using BooksCatalog.Infra.Services.Storage.Contracts;
using BooksCatalog.Shared.Specifications;
using Moq;
using NUnit.Framework;

namespace BooksCatalog.Api.Tests
{
    public class BookServiceTests
    {
        private IBooksService _booksService;
        private Mock<IBookRepository> _bookRepositoryMock;
        private Mock<IAuthorRepository> _authorRepositoryMock;
        private Mock<IPublisherRepository> _publisherRepositoryMock;
        private Mock<IGenreRepository> _genresRepositoryMock;
        private Mock<IStorageService> _storageServiceMock;
        private Mock<IMessagePublisher> _messagePublisherMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new();
            _publisherRepositoryMock = new();
            _authorRepositoryMock = new();
            _genresRepositoryMock = new();
            _storageServiceMock = new();
            _messagePublisherMock = new();
            _mapperMock = new();
            
            _booksService = new BooksService(
                _bookRepositoryMock.Object,
                _mapperMock.Object,
                _authorRepositoryMock.Object,
                _genresRepositoryMock.Object,
                _publisherRepositoryMock.Object,
                _storageServiceMock.Object,
                _messagePublisherMock.Object);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true, false)]
        [TestCase(true, true, false)]
        public void AddNewBook_ShouldThrowArgumentNullException_WhenNoRequiredIdsGiven(
            bool shouldAddAuthors, bool shouldAddGenres = true, bool shouldAddPublishers = true)
        {
            var request = new AddNewBookRequest
            {
                Title = "teste",
                Description = "description",
                ReleaseDate = DateTime.Now,
                CoverUri = "",
                AuthorIds = shouldAddAuthors ? new List<int> { 1, 2 } : null,
                GenreIds = shouldAddGenres ? new List<int> { 1, 2 } : null,
                PublisherIds = shouldAddPublishers ? new List<int> { 1, 2 } : null
            };

            Assert.ThrowsAsync<ArgumentNullException>(() => _booksService.AddNewBook(request));

            AssertThatNoRepositoryHasBeenCalled();
        }

        [Test]
        public async Task AddNewBook_ShouldPublishEvent_WhenBookIsSuccessfullyAdded()
        {
            SetupRepositories();

            var request = new AddNewBookRequest
            {
                Title = "teste",
                Description = "description",
                ReleaseDate = DateTime.Now,
                CoverUri = "",
                AuthorIds = new List<int> { 1 },
                GenreIds = new List<int> { 1 },
                PublisherIds = new List<int> { 1 }
            };

            await _booksService.AddNewBook(request);
            
            _messagePublisherMock.Verify(x =>
                x.Publish(It.IsAny<BookCreated>()), Times.Once);
        }

        [Test]
        public void GetBookById_ShouldThrowException_WhenBookIsNotFound()
            => Assert.Throws<BookNotFoundException>(() => _booksService.GetBookById(1));

        [Test]
        public void DeleteBook_ShouldThrowException_WhenBookIsNotFound()
            => Assert.ThrowsAsync<BookNotFoundException>(() => _booksService.DeleteBook(1));
        
        [Test]
        public void UpdateBook_ShouldThrowException_WhenBookIsNotFound()
            => Assert.Throws<BookNotFoundException>(() => _booksService.UpdateBook(new UpdateBookRequest { Id = 1 }));

        private void SetupRepositories()
        {
            _authorRepositoryMock.Setup(x => x.GetBy(It.IsAny<Specification<Author>>()))
                .Returns(() => new List<Author> {new()});
            _genresRepositoryMock.Setup(x => x.GetBy(It.IsAny<Specification<Genre>>()))
                .Returns(() => new List<Genre> {new()});
            _publisherRepositoryMock.Setup(x => x.GetBy(It.IsAny<Specification<Publisher>>()))
                .Returns(() => new List<Publisher> {new()});
        }

        private void AssertThatNoRepositoryHasBeenCalled()
        {
            _bookRepositoryMock.VerifyNoOtherCalls();
            _authorRepositoryMock.VerifyNoOtherCalls();
            _publisherRepositoryMock.VerifyNoOtherCalls();
            _genresRepositoryMock.VerifyNoOtherCalls();
        }
    }
}