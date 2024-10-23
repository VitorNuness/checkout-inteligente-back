using App.DTOs;
using App.Models;
using App.Repositories.Database;
using App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Unit
{
    public class UserRepositoryTests
    {
        private CheckoutDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<CheckoutDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new CheckoutDbContext(options);
            dbContext.Database.EnsureCreated();
            dbContext.Database.EnsureDeleted();
            return dbContext;
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);

            // Adicionando dados no contexto
            context.Users.Add(new User("John Doe", "john@example.com", "password123"));
            context.Users.Add(new User("Jane Smith", "jane@example.com", "password456"));
            await context.SaveChangesAsync();

            // Act
            var users = await repository.GetAll();

            // Assert
            Assert.NotNull(users);
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public async Task FindOrFail_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User("John Doe", "john@example.com", "password123");
            context.Users.Add(user);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.FindOrFail(user.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }

        [Fact]
        public async Task FindOrFail_ShouldThrowException_WhenUserDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await repository.FindOrFail(999));
        }

        [Fact]
        public async Task FindByCredentialsOrFail_ShouldReturnUser_WhenCredentialsMatch()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User("John Doe", "john@example.com", "password123");
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var userCredentialsDTO = new UserCredentialsDTO(
                email: "john@example.com",
                password: "password123"
            );

            // Act
            var result = await repository.FindByCredentialsOrFail(userCredentialsDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }

        [Fact]
        public async Task Store_ShouldAddUserToDatabase()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);

            var userInputDTO = new UserInputDTO(
                name: "John Doe",
                email: "john@example.com",
                password: "password123"
            );

            // Act
            var user = await repository.Store(userInputDTO);

            // Assert
            Assert.NotNull(user);
            Assert.Equal("John Doe", user.Name);
            Assert.Equal(1, context.Users.Count());
        }
    }
}
