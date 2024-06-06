using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;

namespace App.Services
{
    public class ImageService
    {
        private readonly ImageRepository Repository;

        public ImageService()
        {
            this.Repository = new ImageRepository();
        }

        public List<Image>? GetAll()
        {
            return this.Repository.GetAll();
        }

        public Image? GetById(int id)
        {
            return this.Repository.Get(id);
        }

        public void Create(Image data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, Image data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public string SaveImage(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "public/files/images", file.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return path;
        }

        public void UpdateAndDeleteOldImage(int id, IFormFile file)
        {
            Image? image = this.GetById(id);
            if (image != null)
            {
                string oldPath = image.Path;

                string newPath = this.SaveImage(file);

                image.FileName = file.FileName;
                image.Path = newPath;
                this.Update(id, image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }
        }
    }
}
