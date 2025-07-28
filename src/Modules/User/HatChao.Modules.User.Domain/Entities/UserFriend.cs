using HatChao.Modules.User.Domain.Commons.Enums;
using HatChao.SharedKernel.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace HatChao.Modules.User.Domain.Entities;

public class UserFriend : BaseEntity<Guid>
{
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; } = null!;

    public Guid FriendId { get; set; }

    [ForeignKey(nameof(FriendId))]
    public AppUser Friend { get; set; } = null!;

    public FriendShipStatus Status { get; set; }

    private UserFriend()
    {
        Id = Guid.NewGuid();
    }

    public UserFriend(FriendShipStatus status) : this()
    {
        Status = status;
    }
}
