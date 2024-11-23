namespace Core.Test.DTOs;

using Core.DTOs;
using Core.Models;

public class AuthOutputDTOTest
{
    [Fact]
    public void TestAuthOutputDTOCanBeCreated()
    {
        var userOutputDTO = new UserOutputDTO(
            new User(
                name: "Example",
                email: "Email",
                password: "Password"
            )
        );
        var token = "asjdhakjdajkhsdjkahkdad";

        var authOutputDTO = new AuthOutputDTO(
            user: userOutputDTO,
            token: token
        );

        Assert.Equal(userOutputDTO, authOutputDTO.User);
        Assert.Equal(token, authOutputDTO.Token);
    }
}
