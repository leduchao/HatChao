using HatChao.Modules.User.Domain.Commons.Enums;
using HatChao.Modules.User.Domain.ValueObjects;
using HatChao.SharedKernel.Domain.Abstractions;

namespace HatChao.Modules.User.Domain.Entities;

public class AppUser : BaseEntity<Guid>
{
    public string Username { get; set; } = null!;

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public ActivityStatus Status { get; set; }

    public IList<UserFriend> Friends { get; set; } = [];

    public IList<UserFriend> FriendOf { get; set; } = [];

    private AppUser()
    {
        Id = Guid.NewGuid();
    }

    public AppUser(string username, string email, string plainPassword) : this()
    {
        Username = username;
        Email = ValueObjects.Email.Create(email);
        HashedPassword = PasswordHash.Create(plainPassword);
    }
}
