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
    public class PublisherServiceTests
    {
        private IPublishersService _publishersService;
        private Mock<IPublisherRepository> _publishersRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IStorageService> _storageServiceMock;
        private Mock<IMessagePublisher> _messagePublisherMock;
        
        [SetUp]
        public void SetUp()
        {
            _publishersRepositoryMock = new();
            _mapperMock = new();
            _storageServiceMock = new();
            _messagePublisherMock = new();
            
            _publishersService = new PublishersService(
                _publishersRepositoryMock.Object,
                _mapperMock.Object,
                _storageServiceMock.Object,
                _messagePublisherMock.Object);
        }
        
        [Test]
        public void GetAll_ShouldGetByName_WhenBaseFilterNameIsGiven()
        {
            var filter = new BaseFilter {Name = "lovecraft"};

            _publishersService.GetAllPublishers(filter);
            
            _publishersRepositoryMock.Verify(x => x.GetByName(filter.Name), Times.Once);
            _publishersRepositoryMock.Verify(x => x.GetAllAsync(), Times.Never);
        }
    }
}