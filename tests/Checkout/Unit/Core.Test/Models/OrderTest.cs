namespace Core.Test.Models;

using Core.Enums;
using Core.Models;

public class OrderTest
{
    [Fact]
    public void TestOrderCanBeCreated()
    {
        var user = new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
        );

        var order = new Order(user);

        Assert.IsType<int>(order.Id);
        Assert.Equal(user, order.User);
    }

    [Fact]
    public void TestDefaultValues()
    {
        var defaultStatus = EOrderStatus.CURRENT;

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );

        Assert.Equal(defaultStatus, order.Status);
    }

    [Fact]
    public void TestCanCalculateTotalAmount()
    {
        var expectTotal = 0;

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );

        Assert.Equal(expectTotal, order.TotalAmount);
    }

    [Fact]
    public void TestCanAddProduct()
    {
        var expectItemsCount = 1;
        var expectTotal = 1;

        var product = new Product(
            name: "Product",
            quantity: 1,
            price: 1,
            category: new Category("Category")
        );

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );

        order.AddProduct(product);

        Assert.Equal(expectItemsCount, order.Items.Count);
        Assert.Equal(expectTotal, order.TotalAmount);
    }

    [Fact]
    public void TestCanRemoveProduct()
    {
        var expectItemsCount = 0;
        var expectTotal = 0;

        var product = new Product(
            name: "Product",
            quantity: 1,
            price: 1,
            category: new Category("Category")
        );

        var order = new Order(
            new User(
                name: "Exemplo",
                email: "Email",
                password: "Password"
            )
        );

        order.AddProduct(product);
        order.RemoveProduct(product);

        Assert.Equal(expectItemsCount, order.Items.Count);
        Assert.Equal(expectTotal, order.TotalAmount);
    }
}
