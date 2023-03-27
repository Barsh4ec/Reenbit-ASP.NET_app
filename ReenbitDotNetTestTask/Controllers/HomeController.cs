using Microsoft.AspNetCore.Mvc;
using ReenbitDotNetTestTask.Models;
using System.Diagnostics;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace ReenbitDotNetTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public HomeController(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("BlobConnectionString");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, string email)
        {
        string blobstorageconnection = _configuration.GetValue<string>("BlobConnectionString");
        string blobstoragename = _configuration.GetValue<string>("BlobContainerName");
        string connectionString = blobstorageconnection;


        if (file != null && file.Length > 0)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(blobstoragename);
            container.CreateIfNotExists();

            CloudBlockBlob blob = container.GetBlockBlobReference(Path.GetFileName(file.FileName));
            await using (var fileStream = file.OpenReadStream())
            {
                    blob.Metadata.Add("email", email);
                    blob.UploadFromStream(fileStream);
            }
        }

        return RedirectToAction("Index");
    }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

