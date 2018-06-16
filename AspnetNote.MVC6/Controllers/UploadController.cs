using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class UploadController : Controller
    {

        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost, Route("api/upload")] //image upload by post
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            // #construction of image file upload
            //1. Path
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            //2. Name - DateTime, GUID + GUID
            //3. Extension - jpg, png, txt
            //var fileName = Path.GetFileName(file.FileName); //file.FileName why is not get filename??

            var fileFullName = Path.GetFileName(file.FileName).Split('.');
            var fileName = $"{ Guid.NewGuid()}.{ fileFullName[1]}";

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream); //async - await : pair!!!
            }
            return Ok(new {file = "/images/upload/" + fileName, success = true});
        }
    }
}
