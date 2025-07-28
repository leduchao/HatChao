using HatChao.SharedKernel.Domain.Abstractions;

namespace HatChao.Modules.User.Domain.Entities;

public class Group : BaseEntity<Guid>
{
    public string GroupName { get; set; } = null!;

    public string? GroupPicture { get; set; }

    public IList<GroupMember> Members { get; set; } = [];

    private Group()
    {
        Id = Guid.NewGuid();
    }

    public Group(string name) : this()
    {
        GroupName = name;
    }
}
