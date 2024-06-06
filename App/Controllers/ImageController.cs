using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly ImageService Service;

        public ImageController()
        {
            this.Service = new ImageService();
        }

        [HttpGet]
        public ActionResult<List<Image>?> Index()
        {
            return this.Service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Image?> Show(int id)
        {
            Image? image = this.Service.GetById(id);
            if (image != null)
            {
                var imageFile = System.IO.File.OpenRead(image.Path);
                return File(imageFile, "image/*");
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Image> Store([FromForm] IFormFile file, [FromForm] int productId)
        {
            var path = this.Service.SaveImage(file);
            Image image = new Image(null, productId, file.FileName, path);
            this.Service.Create(image);
            return image;
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromForm] IFormFile file)
        {
            this.Service.UpdateAndDeleteOldImage(id, file);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.Service.Delete(id);

            return NoContent();
        }
    }
}
