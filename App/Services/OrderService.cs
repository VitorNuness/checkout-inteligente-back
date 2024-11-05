using System.Text;
using App.DTOs;
using App.Models;
using App.Repositories;

namespace App.Services
{
    public class OrderService
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly ReportService _reportService;
        private readonly OrderRepository _orderRepository;
        private readonly IWebHostEnvironment _environment;

        public OrderService(
            UserService userService,
            ProductService productService,
            ReportService reportService,
            OrderRepository orderRepository,
            IWebHostEnvironment environment
        )
        {
            _userService = userService;
            _productService = productService;
            _reportService = reportService;
            _orderRepository = orderRepository;
            _environment = environment;
        }

        public async Task<List<Order?>> GetUserOrders(int userId)
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

            order.Items?.ForEach(i => i?.Product.AddSale());

            await _orderRepository.Update(order, order);
        }

        public async Task CreateCSVForOrdersBetweenDates(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = await _orderRepository.FindBetweenDates(startDate, endDate);
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("order;date;customer_name;customer_email;product_name;quantity;total");

            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    stringBuilder.AppendLine($"{order.Id};{order.CompletedAt:dd-MM-yyyy};{order.User.Name};{order.User.Email};{item?.Product.Name};{item?.Quantity};{item?.Total}");
                }
            }

            string fileName = $"{DateTime.Now:ddMMyyyy}_orders_{startDate:ddMMyyyy}_{endDate:ddMMyyyy}.csv";
            string filePath = Path.Combine(_environment.WebRootPath, "files", "exports", "csv", fileName);
            await File.WriteAllTextAsync(filePath, stringBuilder.ToString());

            ReportDTO reportDTO = new(
                id: null,
                name: fileName,
                url: "http://localhost:5102/files/exports/csv/" + fileName,
                reference: "Pedidos", 
                createdAt: null
            );

            await this._reportService.CreateReport(reportDTO);
        }

    }
}
