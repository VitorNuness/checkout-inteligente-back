namespace Application.Services;

using System.Text;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Hosting;

public class OrderService(
    IUserService userService,
    IProductService productService,
    IReportService reportService,
    IOrderRepository orderRepository,
    IWebHostEnvironment environment
    ) : IOrderService
{
    private readonly IUserService _userService = userService;
    private readonly IProductService _productService = productService;
    private readonly IReportService _reportService = reportService;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IWebHostEnvironment _environment = environment;

    public async Task<List<Order?>> GetUserOrders(int userId)
    {
        var user = await this._userService.Get(userId);

        return await this._orderRepository.FindWhereUser(user);
    }

    public async Task<Order> GetCurrentUserOrder(int userId)
    {
        var user = await this._userService.Get(userId);

        return await this._orderRepository.FindOrCreateCurrentUserOrder(user);
    }

    public async Task AddProduct(int id, int productId)
    {
        var order = await this._orderRepository.FindOrFail(id);
        var product = await this._productService.GetById(productId);

        order.AddProduct(product);

        await this._orderRepository.Update(order, order);
    }

    public async Task RemoveProduct(int id, int productId)
    {
        var order = await this._orderRepository.FindOrFail(id);
        var product = await this._productService.GetById(productId);

        order.RemoveProduct(product);

        await this._orderRepository.Update(order, order);
    }

    public async Task CompleteOrder(int id)
    {
        var order = await this._orderRepository.FindOrFail(id);

        order.CompleteOrder();

        order.Items?.ForEach(i => i?.Product.AddSale());

        await this._orderRepository.Update(order, order);
    }

    public async Task CreateCSVForOrdersBetweenDates(DateTime startDate, DateTime endDate)
    {
        var orders = await this._orderRepository.FindBetweenDates(startDate, endDate);
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("order;date;customer_name;customer_email;product_name;quantity;total");

        foreach (var order in orders)
        {
            foreach (var item in order.Items)
            {
                stringBuilder.AppendLine($"{order.Id};{order.CompletedAt:dd-MM-yyyy};{order.User.Name};{order.User.Email};{item?.Product.Name};{item?.Quantity};{item?.Total}");
            }
        }

        var fileName = $"{DateTime.Now:ddMMyyyy}_orders_{startDate:ddMMyyyy}_{endDate:ddMMyyyy}.csv";
        var filePath = Path.Combine(this._environment.WebRootPath, "files", "exports", "csv", fileName);
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
