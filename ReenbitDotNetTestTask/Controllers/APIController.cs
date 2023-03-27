using Microsoft.AspNetCore.Mvc;
using ReenbitDotNetTestTask.Models;
using ReenbitDotNetTestTask.Services;
using System.IO;

namespace ReenbitDotNetTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IBlobService _blobService;
        public APIController(IBlobService blobService)
        {
            _blobService = blobService;
        }


        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] MainForm file)
        {
            if (file.File.FileName.Contains(".docx"))
            {
                await _blobService.Upload(file);
                return Ok("success");
            }
            else
            {
                return BadRequest("You can only upload .docx files");
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(string name)
        {
            var docxFileStream = await _blobService.Get(name);
            string filetype = "docx";
            return File(docxFileStream, $"file/{filetype}");
        }
        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download(string name)
        {
            var docxFileStream = await _blobService.Get(name);
            string filetype = "docx";
            return File(docxFileStream, $"file/{filetype}", $"blobfile.{filetype}");
        }
    }
}
