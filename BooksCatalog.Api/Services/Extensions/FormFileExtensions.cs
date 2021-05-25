using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BooksCatalog.Api.Services.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var stream = new MemoryStream();
            await formFile.CopyToAsync(stream);
            return stream.ToArray();
        }
    }
}