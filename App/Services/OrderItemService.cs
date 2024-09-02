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
        private readonly ProductService _productService;
        private readonly OrderItemRepository _orderItemRepository;

        public OrderItemService(
            ProductService productService,
            OrderItemRepository orderItemRepository
        )
        {
            _productService = productService;
            _orderItemRepository = orderItemRepository;
        }

        public List<OrderItem> GetAll()
        {
            return _orderItemRepository.GetAll();
        }

        public OrderItem? GetById(int id)
        {
            return _orderItemRepository.Get(id);
        }

        public OrderItem? GetByProductAndOrder(int productId, int orderId)
        {
            return _orderItemRepository.GetByProductAndOrder(productId, orderId);
        }

        public void Create(OrderItem data)
        {
            _orderItemRepository.Store(data);
        }

        public void Update(int id, OrderItem data)
        {
            _orderItemRepository.Update(id, data);
        }

        public void Delete(int id)
        {
            _orderItemRepository.Delete(id);
        }

        public void AddProduct(int id, int productId)
        {
            OrderItem? item = this.GetById(id);
            Product? product = _productService.GetById(productId);

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
            Product? product = _productService.GetById(productId);

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
