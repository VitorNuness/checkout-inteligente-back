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
        private readonly ImageService _imageService;

        public ImageController(
            ImageService imageService
        )
        {
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult<List<Image>?> Index()
        {
            return _imageService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Image?> Show(int id)
        {
            Image? image = _imageService.GetById(id);
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
            var path = _imageService.SaveImage(file);
            Image image = new Image(null, productId, file.FileName, path);
            _imageService.Create(image);
            return image;
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromForm] IFormFile file)
        {
            _imageService.UpdateAndDeleteOldImage(id, file);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _imageService.Delete(id);

            return NoContent();
        }
    }
}
