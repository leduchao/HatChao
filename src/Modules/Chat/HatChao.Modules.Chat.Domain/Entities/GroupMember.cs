using HatChao.Modules.Chat.Domain.Commons.Enums;
using HatChao.SharedKernel.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace HatChao.Modules.Chat.Domain.Entities;

public class GroupMember : BaseEntity<Guid>
{
    public Guid GroupId { get; set; }

    [ForeignKey(nameof(GroupId))]
    public Group Group { get; set; } = null!;

    public Guid UserId { get; set; }

    public GroupRole Role { get; set; }

    private GroupMember()
    {
        Id = Guid.NewGuid();
    }

    public GroupMember(GroupRole role) : this()
    {
        Role = role;
    }
}
