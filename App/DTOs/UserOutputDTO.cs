using System.Diagnostics.CodeAnalysis;
using App.Models;

namespace App.DTOs
{
    public class UserOutputDTO
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Role { get; set; }

        [SetsRequiredMembers]
        public UserOutputDTO(
            User user
        )
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Role = user.Role.ToString();
        }
    }
}
