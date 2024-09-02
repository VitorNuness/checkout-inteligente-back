using App.Models;
using App.Repositories.Database;

namespace App.Repositories
{
    public class ImageRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public ImageRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public List<Image> GetAll()
        {
            return _dbContext.Images.ToList();
        }

        public Image Get(int id)
        {
            return _dbContext.Images.Where(p => p.Id == id).First();
        }

        public void Store(Image data)
        {
            Product? product = _dbContext.Products.FirstOrDefault(c => c.Id == data.ProductId);

            if (product != null)
            {
                data.Product = product;
                _dbContext.Images.Add(data);
            }

            _dbContext.SaveChanges();
        }

        public void Update(int id, Image data)
        {
            Image image = this.Get(id);
            if (image != null)
            {
                image.Id = id;
                _dbContext.Entry(image).CurrentValues.SetValues(data);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Images.Remove(this.Get(id));
            _dbContext.SaveChanges();
        }
    }
}
