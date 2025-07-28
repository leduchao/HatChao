using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Infrastructure.Data;
using HatChao.SharedKernel.Domain.Abstractions;

namespace HatChao.Modules.User.Infrastructure.Implements;

public class BaseRepository<TEntity>(UserDbContext dbContext) : IBaseRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    private readonly UserDbContext _dbContext = dbContext;

    public void Add(TEntity entity)
    {
        _dbContext.Add(entity);
    }

    public void AddRange(IList<TEntity> entities)
    {
        _dbContext.AddRange(entities);
    }

    public void Remove(TEntity entity, bool softDelete = false)
    {
        if (softDelete)
        {
            entity.IsDeleted = true;
            _dbContext.Update(entity);
        }
        else
        {
            _dbContext.Remove(entity);
        }
    }

    public void RemoveRangeAsync(IList<TEntity> entities, bool softDelete = false)
    {
        if (softDelete)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            _dbContext.UpdateRange(entities);
        }
        else
        {
            _dbContext.RemoveRange(entities);
        }
    }

    public void Update(TEntity entity)
    {
        _dbContext.Update(entity);
    }

    public void UpdateRange(IList<TEntity> entities)
    {
        _dbContext.UpdateRange(entities);
    }
}
