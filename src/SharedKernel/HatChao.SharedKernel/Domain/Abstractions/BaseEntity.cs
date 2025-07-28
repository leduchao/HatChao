using System.ComponentModel.DataAnnotations;

namespace HatChao.SharedKernel.Domain.Abstractions;

public abstract class BaseEntity<TId>
{
    [Key]
    public TId Id { get; protected set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;
}
