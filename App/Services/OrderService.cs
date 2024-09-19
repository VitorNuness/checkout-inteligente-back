using App.Models;
using App.Repositories;

namespace App.Services
{
    public class OrderService
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly OrderRepository _orderRepository;

        public OrderService(
            UserService userService,
            ProductService productService,
            OrderRepository orderRepository
        )
        {
            _userService = userService;
            _productService = productService;
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetCurrentUserOrder(int userId)
        {
            User user = await _userService.Get(userId);

            return await _orderRepository.FindOrCreateCurrentUserOrder(user);
        }

        public async Task AddProduct(int id, int productId)
        {
            Order order = await _orderRepository.FindOrFail(id);
            Product product = await _productService.GetById(productId);

            OrderItem? orderItem = order.Items?.Find(i => i?.Product?.Id == productId);

            if (orderItem != null)
            {
                orderItem.AddQuantity();
            }
            else
            {
                orderItem = new(product, order);
                order.Items?.Add(orderItem);
            }

            order.CalculateTotal();

            await _orderRepository.Update(order, order);
        }

        public async Task RemoveProduct(int id, int productId)
        {
            Order order = await _orderRepository.FindOrFail(id);
            Product product = await _productService.GetById(productId);

            OrderItem? orderItem = order.Items?.Find(i => i?.Product?.Id == productId);

            orderItem?.RemoveQuantity();

            if (orderItem?.Quantity <= 0)
            {
                order.Items?.Remove(orderItem);
            }

            order.CalculateTotal();

            await _orderRepository.Update(order, order);
        }
    }
}
