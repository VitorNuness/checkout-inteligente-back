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
        string password
    )
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }

    private User() {}
}
