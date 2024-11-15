namespace Core.Test.DTOs;

using Core.DTOs;

public class CategoryInputDTOTest
{
    [Fact]
    public void TestCategoryInputDTOCanBeCreated()
    {
        var name = "Category";

        var categoryInputDTO = new CategoryInputDTO(name);

        Assert.Equal(name, categoryInputDTO.Name);
    }
}
