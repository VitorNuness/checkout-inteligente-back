using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;

namespace App.Services
{
    public class OrderItemService
    {
        private readonly ProductService ProductService;
        private readonly OrderItemRepository Repository;

        public OrderItemService()
        {
            this.ProductService = new ProductService();
            this.Repository = new OrderItemRepository();
        }

        public List<OrderItem> GetAll()
        {
            return this.Repository.GetAll();
        }

        public OrderItem? GetById(int id)
        {
            return this.Repository.Get(id);
        }

        public OrderItem? GetByProductAndOrder(int productId, int orderId)
        {
            return this.Repository.GetByProductAndOrder(productId, orderId);
        }

        public void Create(OrderItem data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, OrderItem data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public void AddProduct(int id, int productId)
        {
            OrderItem? item = this.GetById(id);
            Product? product = this.ProductService.GetById(productId);

            if (item != null && product != null)
            {
                item.Quantity++;
                item.Total = item.Quantity * item.Product.Price;
                this.Update(id, item);
            }
        }

        public void RemoveProduct(int id, int productId)
        {
            OrderItem? item = this.GetById(id);
            Product? product = this.ProductService.GetById(productId);

            if (item != null && product != null)
            {
                item.Quantity--;
                item.Total = item.Quantity * item.Product.Price;
                if (item.Quantity == 0)
                {
                    this.Delete(id);
                }
                else
                {
                    this.Update(id, item);
                }
            }
        }
    }
}
