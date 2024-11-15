namespace Core.Test.DTOs;

using Core.DTOs;
using Core.Models;

public class UserOutputDTOTest
{
    [Fact]
    public void TestUserOutputDTOCanBeCreated()
    {
        var user = new User(
            name: "Example",
            email: "Email",
            password: "Password"
        );

        var userOutputDTO = new UserOutputDTO(user);

        Assert.Equal(user.Id, userOutputDTO.Id);
        Assert.Equal(user.Name, userOutputDTO.Name);
        Assert.Equal(user.Email, userOutputDTO.Email);
        Assert.Equal(user.Role.ToString(), userOutputDTO.Role);
    }
}
