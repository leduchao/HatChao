using HatChao.Modules.User.Domain.ValueObjects;
using HatChao.SharedKernel.Domain.Abstractions;

namespace HatChao.Modules.User.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public User()
    {
        Id = Guid.NewGuid();
    }

    public User(string username, string email, string plainPassword) : this()
    {
        Username = username;
        Email = ValueObjects.Email.Create(email);
        HashedPassword = PasswordHash.Create(plainPassword);
    }
}
