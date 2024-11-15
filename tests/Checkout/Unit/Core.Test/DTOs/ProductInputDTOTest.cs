namespace Core.Test.DTOs;

using Core.DTOs;

public class ProductInputDTOTest
{
    [Fact]
    public void TestProductInputDTOCanBeCreated()
    {
        var name = "Product";
        var quantity = 1;
        var price = 1;
        var categoryId = 1;

        var productInputDTO = new ProductInputDTO(
            name: name,
            quantity: quantity,
            price: price,
            categoryId: categoryId
        );

        Assert.Equal(name, productInputDTO.Name);
        Assert.Equal(quantity, productInputDTO.Quantity);
        Assert.Equal(price, productInputDTO.Price);
        Assert.Equal(categoryId, productInputDTO.CategoryId);
    }
}
