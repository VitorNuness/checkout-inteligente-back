using System.Diagnostics.CodeAnalysis;

namespace App.DTOs
{
    public class UserCredentialsDTO
    {
        public required string Email { get; set; }

        public required string Password { get; set; }

        [SetsRequiredMembers]
        public UserCredentialsDTO(
            string email,
            string password
        )
        {
            Email = email;
            Password = password;
        }
    }
}
