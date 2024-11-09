namespace Core.Test.Models;

using Core.Models;

public class ProductTest
{
    [Fact]
    public void TestProductCanBeCreated()
    {
        var name = "Product";
        var quantity = 1;
        var price = 1;
        var category = new Category("Category");

        var product = new Product(
            name: name,
            quantity: quantity,
            price: price,
            category: category
        );

        Assert.IsType<int>(product.Id);
        Assert.Equal(name, product.Name);
        Assert.Equal(quantity, product.Quantity);
        Assert.Equal(price, product.Price);
    }

    [Fact]
    public void TestDefaultImageUrl()
    {
        var defaultUrl = "http://localhost:5102/files/images/products/0.png";

        var product = new Product(
            name: "Product",
            quantity: 1,
            price: 1,
            category: new Category("Category")
        );

        Assert.Equal(defaultUrl, product.ImageUrl);
    }

    [Fact]
    public void TestDefaultSalesValue()
    {
        var product = new Product(
            name: "Product",
            quantity: 1,
            price: 1,
            category: new Category("Category")
        );

        Assert.Equal(0, product.Sales);
    }

    [Fact]
    public void TestCanAddSales()
    {
        var product = new Product(
            name: "Product",
            quantity: 1,
            price: 1,
            category: new Category("Category")
        );

        product.AddSale();

        Assert.Equal(1, product.Sales);
    }
}
