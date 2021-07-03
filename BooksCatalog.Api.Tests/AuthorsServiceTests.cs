using AutoMapper;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Services;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Domain.Interfaces.Messaging;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Infra.Services.Storage.Contracts;
using Moq;
using NUnit.Framework;

namespace BooksCatalog.Api.Tests
{
    public class AuthorsServiceTests
    {
        private IAuthorsService _authorsService;
        private Mock<IAuthorRepository> _authorsRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IStorageService> _storageServiceMock;
        private Mock<IMessagePublisher> _messagePublisherMock;

        [SetUp]
        public void SetUp()
        {
            _authorsRepositoryMock = new();
            _mapperMock = new();
            _storageServiceMock = new();
            _messagePublisherMock = new();
            
            _authorsService = new AuthorsService(
                _authorsRepositoryMock.Object,
                _mapperMock.Object,
                _storageServiceMock.Object,
                _messagePublisherMock.Object);
        }
        
        [Test]
        public void GetAll_ShouldGetByName_WhenBaseFilterNameIsGiven()
        {
            var filter = new BaseFilter {Name = "lovecraft"};

            _authorsService.GetAll(filter);
            
            _authorsRepositoryMock.Verify(x => x.GetByName(filter.Name), Times.Once);
            _authorsRepositoryMock.Verify(x => x.GetAllAsync(), Times.Never);
        }
    }
}