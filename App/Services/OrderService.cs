using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class OrderService : IOrderService
    {
        private readonly ProductService _productService;
        private readonly SuggestionService _suggestionService;
        private readonly CampaignService _campaignService;
        private readonly OrderItemService _orderItemService;
        private readonly OrderRepository _orderRepository;

        public OrderService(
            ProductService productService,
            SuggestionService suggestionService,
            CampaignService campaignService,
            OrderItemService orderItemService,
            OrderRepository orderRepository
        )
        {
            _productService = productService;
            _suggestionService = suggestionService;
            _campaignService = campaignService;
            _orderItemService = orderItemService;
            _orderRepository = orderRepository;
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order? GetById(int id)
        {
            return _orderRepository.Get(id);
        }

        public Order? GetCurrentUserOrder(int userId)
        {
            return _orderRepository.GetCurrentUserOrder(userId);
        }

        public void Create(Order data)
        {
            _orderRepository.Store(data);
        }

        public void Update(int id, Order data)
        {
            _orderRepository.Update(id, data);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public void AddProduct(int id, int productId)
        {
            Order? order = this.GetById(id);
            Product? product = _productService.GetById(productId);

            if (order != null && product != null)
            {
                OrderItem? item = _orderItemService.GetByProductAndOrder(productId, order.Id);

                if (item == null)
                {
                    item = new OrderItem(productId, product, 1, id, order);
                }

                if (order.Items != null && order.Items.Any(i => i.ProductId == productId))
                {
                    _orderItemService.AddProduct(item.Id, productId);
                }
                else
                {
                    order.Items.Add(item);
                }
                order = this.VerifyFreeShiping(order);
                this.Update(id, order);

            }
        }


        public void RemoveProduct(int id, int productId)
        {
            Order? order = this.GetById(id);
            Product? product = _productService.GetById(productId);

            if (order != null && product != null)
            {
                OrderItem? item = _orderItemService.GetByProductAndOrder(productId, order.Id);
                if (order.Items != null && order.Items.Any(i => i.ProductId == productId))
                {
                    _orderItemService.RemoveProduct(item.Id, productId);
                }
                order = this.VerifyFreeShiping(order);
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
                    _productService.AddView(item.ProductId);
                }
            }
        }

        public List<Product>? GetSuggestions(int id)
        {
            Order? order = this.GetById(id);
            List<Product>? products = _productService.GetAll(null, "popularity");

            List<Product>? suggestions = _suggestionService.GetSuggestions(order, products);
            return suggestions;
        }

        public List<Product>? GetSuggestionsByCampaigns(int id)
        {
            Order? order = this.GetById(id);
            List<Campaign>? campaigns = _campaignService.GetAll("active");
            List<Product>? products = new List<Product>();

            if (campaigns != null && order != null && !order.FreeShipping)
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

            List<Product>? suggestions = _suggestionService.GetSuggestions(order, products);
            return suggestions;
        }

        public Order VerifyFreeShiping(Order order)
        {
            List<Campaign>? campaigns = _campaignService.GetAll("active");
            HashSet<Product> productsInCampaigns = new HashSet<Product>();

            if (order != null && campaigns != null)
            {
                foreach (Campaign campaign in campaigns)
                {
                    if (campaign.Products != null && order.Items != null)
                    {
                        foreach (Product product in campaign.Products)
                        {
                            foreach (OrderItem item in order.Items)
                            {
                                if (product == item.Product)
                                {
                                    productsInCampaigns.Add(product);
                                }
                            }
                        }
                        if (productsInCampaigns.Count() == campaign.Products.Count())
                        {
                            order.FreeShipping = true;
                            return order;
                        }
                        else
                        {
                            order.FreeShipping = false;
                        }
                        productsInCampaigns.Clear();
                    }
                }
            }
            return order;
        }

    }
}
