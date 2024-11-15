namespace Core.Test.Models;

using Core.Models;

public class OrderItemTest
{
    [Fact]
    public void TestOrderItemCanBeCreated()
    {
        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );
        var product = new Product(
            name: "product",
            quantity: 10,
            price: 4,
            category: new Category("Category")
        );

        var orderItem = new OrderItem(
            product: product,
            order: order
        );

        Assert.IsType<int>(orderItem.Id);
        Assert.Equal(product, orderItem.Product);
        Assert.Equal(order, orderItem.Order);
    }

    [Fact]
    public void TestDefaultValues()
    {
        var defaultQuantity = 1;

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );
        var product = new Product(
            name: "product",
            quantity: 10,
            price: 4,
            category: new Category("Category")
        );

        var orderItem = new OrderItem(
            product: product,
            order: order
        );

        Assert.Equal(defaultQuantity, orderItem.Quantity);
    }

    [Fact]
    public void TestCanCalculateTotal()
    {
        var expectTotal = 4;

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );
        var product = new Product(
            name: "product",
            quantity: 10,
            price: 4,
            category: new Category("Category")
        );

        var orderItem = new OrderItem(
            product: product,
            order: order
        );

        Assert.Equal(expectTotal, orderItem.Total);
    }

    [Fact]
    public void TestCanAddQuantity()
    {
        var expectQuantity = 2;
        var expectTotal = 8;

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );
        var product = new Product(
            name: "product",
            quantity: 10,
            price: 4,
            category: new Category("Category")
        );

        var orderItem = new OrderItem(
            product: product,
            order: order
        );
        orderItem.AddQuantity();

        Assert.Equal(expectQuantity, orderItem.Quantity);
        Assert.Equal(expectTotal, orderItem.Total);
    }

    [Fact]
    public void TestCanRemoveQuantity()
    {
        var expectQuantity = 0;
        var expectTotal = 0;

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );
        var product = new Product(
            name: "product",
            quantity: 10,
            price: 4,
            category: new Category("Category")
        );

        var orderItem = new OrderItem(
            product: product,
            order: order
        );
        orderItem.RemoveQuantity();

        Assert.Equal(expectQuantity, orderItem.Quantity);
        Assert.Equal(expectTotal, orderItem.Total);
    }
}
