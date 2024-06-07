using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class OrderService : IOrderService
    {
        private readonly ProductService ProductService;
        private readonly SuggestionService SuggestionService;
        private readonly CampaignService CampaignService;
        private readonly OrderItemService OrderItemService;
        private readonly OrderRepository Repository;

        public OrderService()
        {
            this.ProductService = new ProductService();
            this.SuggestionService = new SuggestionService();
            this.CampaignService = new CampaignService();
            this.OrderItemService = new OrderItemService();
            this.Repository = new OrderRepository();
        }

        public List<Order> GetAll()
        {
            return this.Repository.GetAll();
        }

        public Order? GetById(int id)
        {
            return this.Repository.Get(id);
        }

        public Order? GetCurrentUserOrder(int userId)
        {
            return this.Repository.GetCurrentUserOrder(userId);
        }

        public void Create(Order data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, Order data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public void AddProduct(int id, int productId)
        {
            Order? order = this.GetById(id);
            Product? product = this.ProductService.GetById(productId);

            if (order != null && product != null)
            {
                OrderItem? item = this.OrderItemService.GetByProductAndOrder(productId, order.Id);

                if (item == null)
                {
                    item = new OrderItem(productId, product, 1, id, order);
                }

                if (order.Items != null && order.Items.Any(i => i.ProductId == productId))
                {
                    this.OrderItemService.AddProduct(item.Id, productId);
                }
                else
                {
                    order.Items.Add(item);
                    this.Update(id, order);
                }

            }
        }


        public void RemoveProduct(int id, int productId)
        {
            Order? order = this.GetById(id);
            Product? product = this.ProductService.GetById(productId);

            if (order != null && product != null)
            {
                OrderItem? item = this.OrderItemService.GetByProductAndOrder(productId, order.Id);
                if (order.Items != null && order.Items.Any(i => i.ProductId == productId))
                {
                    this.OrderItemService.RemoveProduct(item.Id, productId);
                }
                this.Update(id, order);
            }
        }

        public void CompleteOrder(int id)
        {
            Order? order = this.GetById(id);
            if (order != null && order.Items != null)
            {
                order.IsComplete = true;
                this.Update(id, order);

                Order? newOrder = new Order(order.User, order.UserId);
                this.Create(newOrder);

                foreach (OrderItem? item in order.Items)
                {
                    this.ProductService.AddView(item.ProductId);
                }
            }
        }

        public List<Product>? GetSuggestions(int id)
        {
            Order? order = this.GetById(id);
            List<Product>? products = this.ProductService.GetAll(null, "popularity");

            List<Product>? suggestions = this.SuggestionService.GetSuggestions(order, products);
            return suggestions;
        }

        public List<Product>? GetSuggestionsByCampaigns(int id)
        {
            Order? order = this.GetById(id);
            List<Campaign>? campaigns = this.CampaignService.GetAll("active");
            List<Product>? products = new List<Product>();

            if (campaigns != null)
            {
                foreach (Campaign campaign in campaigns)
                {
                    if (campaign.Products != null)
                    {
                        foreach (Product product in campaign.Products)
                        {
                            products.Add(product);
                        }
                    }
                }
            }

            products = products.OrderByDescending(p => p.Views).ToList();

            List<Product>? suggestions = this.SuggestionService.GetSuggestions(order, products);
            return suggestions;
        }
    }
}
