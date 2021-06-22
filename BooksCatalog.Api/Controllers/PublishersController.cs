using System.Threading.Tasks;
using BooksCatalog.Api.Models.Filters;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("/api/publishers")]
    [Authorize]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersService _publishersService;

        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] BaseFilter filter)
        {
            filter ??= new BaseFilter();
            var publishers = _publishersService.GetAllPublishers(filter);
            return Ok(publishers);
        }

        [HttpGet("{publisherId:int}")]
        [AllowAnonymous]
        public IActionResult GetPublishersById(int publisherId)
        {
            try
            {
                var publisher = _publishersService.GetPublisherById(publisherId);
                return Ok(publisher);
            }
            catch (PublisherNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPublisher([FromBody] AddNewPublisherRequest request)
        {
            await _publishersService.AddNewPublisher(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePublisher([FromBody] UpdatePublisherRequest request)
        {
            try
            {
                _publishersService.UpdatePublisher(request);
                return Ok();
            }
            catch (PublisherNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{publisherId:int}")]
        public IActionResult DeletePublisher(int publisherId)
        {
            try
            {
                _publishersService.DeletePublisher(publisherId);
                return Ok();
            }
            catch (PublisherNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var response = await _publishersService.UploadImage(file);
            return Ok(response);
        }
    }
}