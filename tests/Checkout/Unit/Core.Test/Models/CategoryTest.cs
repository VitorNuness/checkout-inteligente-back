namespace Core.Test.Models;

using Core.Models;

public class CategoryTest
{
    [Fact]
    public void TestCategoryCanBeCreated()
    {
        var name = "Category";

        var category = new Category(
            name: name
        );

        Assert.Equal(name, category.Name);
    }

    [Fact]
    public void TestDefaultImageUrl()
    {
        var imageUrl = "http://localhost:5102/files/images/categories/0.png";

        var category = new Category(name: "Category");

        Assert.Equal(imageUrl, category.ImageUrl);
    }
}
