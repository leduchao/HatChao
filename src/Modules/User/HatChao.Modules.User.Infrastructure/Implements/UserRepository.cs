using Dapper;
using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.Entities;
using HatChao.Modules.User.Infrastructure.Data;
using System.Data;

namespace HatChao.Modules.User.Infrastructure.Implements;

public class UserRepository(UserDbContext dbContext, IDbConnection dbConnection) : BaseRepository<AppUser>(dbContext), IUserRepository
{
	private readonly IDbConnection _dbConnection = dbConnection;

	public async Task<bool> IsUserExistsAsync(string email)
	{
		string sql = @"SELECT Email FROM AppUsers WHERE Email = @Email";
		var result = await _dbConnection.QueryAsync(sql, new { Email = email });

		return result.Any();
	}
}
