using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BooksCatalog.Infra.Services.Contracts;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Infra.Services
{
    public class BlobStorage : IStorageService
    {
        private readonly string _connectionString;

        public BlobStorage(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<string> UploadFile(byte[] stream, string filename, string containerName)
        {
            Guard.Against.NullOrEmpty(filename, nameof(filename));
            Guard.Against.FilenameWithoutExtension(filename);
            Guard.Against.InvalidContainerName(containerName);

            var blobClient = GetBlobClient(filename, containerName);

            await using var fileStream = new MemoryStream(stream);
            await blobClient.UploadAsync(fileStream, true);
            
            return blobClient.Uri.ToString();
        }

        private BlobClient GetBlobClient(string filename, string containerName)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            containerClient.CreateIfNotExists(PublicAccessType.Blob);

            var blobClient = containerClient.GetBlobClient(filename);
            return blobClient;
        }
    }
}