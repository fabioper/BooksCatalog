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
    public class GenresServiceTests
    {
        private IGenresService _genresService;
        private Mock<IGenreRepository> _genresRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IMessagePublisher> _messagePublisherMock;
        
        [SetUp]
        public void SetUp()
        {
            _genresRepositoryMock = new();
            _mapperMock = new();
            _messagePublisherMock = new();
            
            _genresService = new GenresService(
                _genresRepositoryMock.Object,
                _mapperMock.Object,
                _messagePublisherMock.Object);
        }
        
        [Test]
        public void GetAll_ShouldGetByName_WhenBaseFilterNameIsGiven()
        {
            var filter = new BaseFilter {Name = "lovecraft"};

            _genresService.GetAll(filter);
            
            _genresRepositoryMock.Verify(x => x.GetByName(filter.Name), Times.Once);
            _genresRepositoryMock.Verify(x => x.GetAllAsync(), Times.Never);
        }
    }
}