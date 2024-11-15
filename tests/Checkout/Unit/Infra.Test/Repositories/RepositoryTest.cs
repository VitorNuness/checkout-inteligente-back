namespace Infra.Test.Repositories;

using Infra.Repositories.Database;
using Microsoft.EntityFrameworkCore;

public class RepositoryTest
{
    protected readonly CheckoutDbContext Context;

    public RepositoryTest()
    {
        var options = new DbContextOptionsBuilder<CheckoutDbContext>()
            .UseInMemoryDatabase(databaseName: "TesteDb")
            .Options;

        this.Context = new CheckoutDbContext(options);
    }
}
