namespace Core.Test.DTOs;

using Core.DTOs;
using Core.Models;

public class OrderDTOTest
{
    [Fact]
    public void TestOrderDTOCanBeCreated()
    {
        var order = new Order(
            new User(
                name: "User",
                email: "Email",
                password: "Password"
            )
        );

        var orderDTO = new OrderDTO(order);

        Assert.Equal(order.Id, orderDTO.Id);
        Assert.Equal(order.User.Id, orderDTO.UserId);
        Assert.Equal(order.Status.ToString(), orderDTO.Status);
        Assert.Equal(order.TotalAmount, orderDTO.TotalAmount);
        Assert.IsType<List<OrderItemDTO?>>(orderDTO.Items);
    }
}
