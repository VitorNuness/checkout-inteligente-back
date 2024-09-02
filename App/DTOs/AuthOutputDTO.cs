using System.Diagnostics.CodeAnalysis;

namespace App.DTOs
{
    public class AuthOutputDTO
    {
        public required UserOutputDTO User { get; set; }

        public required string Token { get; set; }

        [SetsRequiredMembers]
        public AuthOutputDTO(
            UserOutputDTO userOutputDTO,
            string token
        )
        {
            User = userOutputDTO;
            Token = token;
        }
    }
}
