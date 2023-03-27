
using Azure.Storage.Blobs.Models;
using ReenbitDotNetTestTask.Models;

namespace ReenbitDotNetTestTask.Services
{
    public interface IBlobService
    {
        Task Upload(MainForm filemodel);
        Task<Stream> Get(string name);
    }
}

