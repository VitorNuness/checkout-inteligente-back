using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Enums;

namespace App.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required ERole Role { get; set; }

        public User(string name, string email, string password, ERole role = ERole.CUSTOMER)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        private User() { }
    }
}
