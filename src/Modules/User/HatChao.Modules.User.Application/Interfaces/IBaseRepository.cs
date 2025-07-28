using HatChao.SharedKernel.Domain.Abstractions;

namespace HatChao.Modules.User.Application.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    void Add(TEntity entity);

    void AddRange(IList<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(IList<TEntity> entities);

    void Remove(TEntity entity, bool softDelete = false);

    void RemoveRangeAsync(IList<TEntity> entities, bool softDelete = false);
}
