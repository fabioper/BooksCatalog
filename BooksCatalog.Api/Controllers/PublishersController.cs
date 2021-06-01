﻿using System.Threading.Tasks;
using BooksCatalog.Api.Models.Requests;
using BooksCatalog.Api.Services.Contracts;
using BooksCatalog.Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers
{
    [ApiController]
    [Route("/api/publishers")]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersService _publishersService;

        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publishersService.GetAllPublishers();
            return Ok(publishers);
        }

        [HttpGet("{publisherId:int}")]
        public async Task<IActionResult> GetPublishersById(int publisherId)
        {
            try
            {
                var publisher = await _publishersService.GetPublisherById(publisherId);
                return Ok(publisher);
            }
            catch (PublisherNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPublisher([FromBody] AddNewPublisher request)
        {
            await _publishersService.AddNewPublisher(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePublisher([FromBody] UpdatePublisherRequest request)
        {
            try
            {
                await _publishersService.UpdatePublisher(request);
                return Ok();
            }
            catch (PublisherNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{publisherId:int}")]
        public async Task<IActionResult> DeletePublisher(int publisherId)
        {
            try
            {
                await _publishersService.DeletePublisher(publisherId);
                return NotFound();
            }
            catch (PublisherNotFoundException)
            {
                return NotFound();
            }
        }
    }
}