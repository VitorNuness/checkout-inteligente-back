using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class OrderService
    {
        private readonly UserService _userService;
        private readonly OrderRepository _orderRepository;

        public OrderService(
            UserService userService,
            OrderRepository orderRepository
        )
        {
            _userService = userService;
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetCurrentUserOrder(int userId)
        {
            User user = await _userService.Get(userId);

            return await _orderRepository.FindOrCreateCurrentUserOrder(user);
        }
    }
}
