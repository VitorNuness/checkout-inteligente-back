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

        public async Task<List<Order>> GetUserOrders(int userId)
        {
            User user = await _userService.Get(userId);

            return await _orderRepository.FindWhereUser(user);
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

            order.AddProduct(product);

            await _orderRepository.Update(order, order);
        }

        public async Task RemoveProduct(int id, int productId)
        {
            Order order = await _orderRepository.FindOrFail(id);
            Product product = await _productService.GetById(productId);

            order.RemoveProduct(product);

            await _orderRepository.Update(order, order);
        }

        public async Task CompleteOrder(int id)
        {
            Order order = await _orderRepository.FindOrFail(id);

            order.CompleteOrder();

            await _orderRepository.Update(order, order);
        }
    }
}
