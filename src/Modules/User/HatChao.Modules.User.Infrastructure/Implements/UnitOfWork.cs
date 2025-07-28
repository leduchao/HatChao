using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Infrastructure.Data;

namespace HatChao.Modules.User.Infrastructure.Implements;

public class UnitOfWork(UserDbContext dbContext) : IUnitOfWork
{
	private readonly UserDbContext _dbContext = dbContext;

	public async Task<int> SaveChangesAsync()
	{
		return await _dbContext.SaveChangesAsync();
	}
}
