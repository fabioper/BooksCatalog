using Microsoft.AspNetCore.Http;

namespace BooksCatalog.Api.Models.Requests
{
    public class UploadImageRequest
    {
        public IFormFile Data { get; set; }
        public string Name { get; set; }
    }
}