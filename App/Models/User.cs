namespace App.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using App.Enums;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int? Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required ERole Role { get; set; }

    [SetsRequiredMembers]
    public User(string name, string email, string password, ERole role = ERole.CUSTOMER)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Role = role;
    }

    private User() { }
}
