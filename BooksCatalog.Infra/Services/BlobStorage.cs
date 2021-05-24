using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using BooksCatalog.Application.Services.Contracts;

namespace BooksCatalog.Infra.Services
{
    public class BlobStorage : IStorageService
    {
        private readonly string _connectionString;
        private readonly string _containerName;
        
        public BlobStorage(string connectionString, string containerName)
        {
            _connectionString = connectionString;
            _containerName = containerName;
        }
        
        public async Task<string> UploadFile(byte[] stream, string filename)
        {
            var blobClient = GetBlobClient(filename);

            await using var fileStream = new MemoryStream(stream);
            await blobClient.UploadAsync(fileStream, true);
            
            return blobClient.Uri.ToString();
        }

        private BlobClient GetBlobClient(string filename)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(filename);
            return blobClient;
        }
    }
}