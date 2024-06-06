using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class ImageRepository
    {
        private readonly CheckoutDbContext DbContext;

        public ImageRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Image> GetAll()
        {
            return this.DbContext.Images.ToList();
        }

        public Image Get(int id)
        {
            return this.DbContext.Images.Where(p => p.Id == id).First();
        }

        public void Store(Image data)
        {
            Product? product = this.DbContext.Products.FirstOrDefault(c => c.Id == data.ProductId);

            if (product != null)
            {
                data.Product = product;
                this.DbContext.Images.Add(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Update(int id, Image data)
        {
            Image image = this.Get(id);
            if (image != null)
            {
                image.Id = id;
                this.DbContext.Entry(image).CurrentValues.SetValues(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            this.DbContext.Images.Remove(this.Get(id));
            this.DbContext.SaveChanges();
        }
    }
}
