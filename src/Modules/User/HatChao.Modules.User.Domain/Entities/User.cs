using HatChao.Modules.User.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace HatChao.Modules.User.Domain.Entities;

[Table("users")]
public class User : BaseEntity
{
    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("hashed_password")]
    public string HashedPassword { get; set; } = null!;

    public User() {}

    public User(string username, string email, string plainPassword)
    {
        Username = username;
        Email = ValueObjects.Email.Create(email);
        HashedPassword = PasswordHash.Create(plainPassword);
    }
}
