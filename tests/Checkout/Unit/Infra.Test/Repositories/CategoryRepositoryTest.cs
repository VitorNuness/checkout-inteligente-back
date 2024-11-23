namespace Infra.Test.Repositories;

using Core.Models;
using Infra.Repositories;

public class CategoryRepositoryTest : RepositoryTest
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryRepositoryTest() => this._categoryRepository = new CategoryRepository(this.Context);

    [Fact]
    public void TestCanGetAllCategories()
    {
        Category category1 = new(name: "Category 1");
        Category category2 = new(name: "Category 2");
        Category category3 = new(name: "Category 3");
        this.Context.Categories.AddRange(
            category1, category2, category3);
        this.Context.SaveChanges();

        var categories = this._categoryRepository.GetAll();

        Assert.Equal(3, categories.Result.Count);
        Assert.Equal(category1, categories.Result[0]);
        Assert.Equal(category2, categories.Result[1]);
        Assert.Equal(category3, categories.Result[2]);
    }

    [Fact]
    public async void TestCanCreateACategory()
    {
        var categoryName = "Category";

        await this._categoryRepository.Store(new Category(categoryName));

        var category = this.Context.Categories.FirstOrDefault();
        Assert.NotNull(category);
        Assert.Equal(categoryName, category.Name);
    }

    [Fact]
    public async void TestCanUpdateACategory()
    {
        Category category = new("Category") { Id = 45698 };
        this.Context.Categories.Add(category);
        this.Context.SaveChanges();
        var newCategory = new Category("Category Updated");

        await this._categoryRepository.Update(category, newCategory);

        var categoryUpdated = this.Context.Categories.FirstOrDefault();

        Assert.Equal(newCategory.Id, categoryUpdated!.Id);
        Assert.Equal(newCategory.Name, categoryUpdated!.Name);
    }

    [Fact]
    public async void TestCanDeleteACategory()
    {
        Category category = new("Category") { Id = 45698 };
        this.Context.Categories.Add(category);
        this.Context.SaveChanges();

        await this._categoryRepository.Delete(category);

        var categories = this.Context.Categories.ToList();

        Assert.Empty(categories);
    }
}
