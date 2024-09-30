using System.Diagnostics.CodeAnalysis;

namespace App.DTOs
{
    public class UserInputDTO
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        [SetsRequiredMembers]
        public UserInputDTO(
            string name,
            string email,
            string password
        )
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
