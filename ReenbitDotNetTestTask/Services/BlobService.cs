using Azure.Storage.Blobs;
using ReenbitDotNetTestTask.Models;

namespace ReenbitDotNetTestTask.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(MainForm filemodel)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("testtask");
            var blobInstance = containerInstance.GetBlobClient(filemodel.File.FileName);
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            metadata.Add("email", filemodel.Email);

            await blobInstance.UploadAsync(filemodel.File.OpenReadStream());
            blobInstance.SetMetadata(metadata);
        }

        public async Task<Stream> Get(string name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("testtask");
            var blobInstance = containerInstance.GetBlobClient(name);
            var downloadcontent = await blobInstance.DownloadAsync();
            return downloadcontent.Value.Content;
        }
    }
}

