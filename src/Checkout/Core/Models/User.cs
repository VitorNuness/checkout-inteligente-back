namespace Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; } = ERole.CUSTOMER;

    public static User WithRoleAdmin(
        string name,
        string email,
        string password
    ) => new(
            name: name,
            email: email,
            password: password
        )
    {
        Role = ERole.ADMIN
    };

    public User(
        string name,
        string email,
        string password
    )
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }

    public User(
        int id,
        string name,
        string email,
        string password,
        ERole role
    )
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Role = role;
    }

    private User() {}
}
