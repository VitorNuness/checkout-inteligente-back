using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Database
{
    public class DatabaseSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CheckoutDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CheckoutDbContext>>()))
            {
                if (!context.Products.Any())
                {
                    Category category = new("Categoria 1");
                    context.Products.AddRange(
                        new Product("Produto 1", category, 10, 100),
                        new Product("Produto 2", category, 10, 100),
                        new Product("Produto 3", category, 10, 100)
                    );
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User("Admin", "admin@email.com", "password", Enums.ERole.ADMIN)
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
