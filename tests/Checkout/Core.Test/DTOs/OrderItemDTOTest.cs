namespace Core.Test.DTOs;

using Core.DTOs;
using Core.Models;

public class OrderItemDTOTest
{
    [Fact]
    public void TestOrderItemDTOCanBeCreated()
    {
        var orderItem = new OrderItem(
            product: new Product(
                name: "Product",
                quantity: 1,
                price: 0,
                new Category("Category")
            ),
            order: new Order(
                new User(
                    name: "Name",
                    email: "Email",
                    password: "Password"
                )
            )
        );

        var orderItemDTO = new OrderItemDTO(orderItem);

        Assert.Equal(orderItem.Product.Id, orderItemDTO.ProductId);
        Assert.Equal(orderItem.Product, orderItemDTO.Product);
        Assert.Equal(orderItem.Quantity, orderItemDTO.Quantity);
        Assert.Equal(orderItem.Total, orderItemDTO.Total);
    }
}
