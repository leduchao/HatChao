using Dapper;

using HatChao.Modules.User.Application.DTOs;
using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.Entities;
using HatChao.Modules.User.Infrastructure.Data;

using System.Data;

namespace HatChao.Modules.User.Infrastructure.Implements;

public class UserRepository(UserDbContext dbContext, IDbConnection dbConnection) : BaseRepository<AppUser>(dbContext), IUserRepository
{
    private readonly IDbConnection _dbConnection = dbConnection;

    public async Task<UserBasicInfo?> GetUserInforAsync(string email)
    {
        string sql = $"""
            SELECT {nameof(AppUser.Id)}, {nameof(AppUser.Username)}, {nameof(AppUser.Email)}, {nameof(AppUser.FullName)}, {nameof(AppUser.ProfilePicture)}
            FROM {nameof(UserDbContext.AppUsers)}
            WHERE {nameof(AppUser.Email)} = @Email
            """;

        var result = await _dbConnection.QueryFirstOrDefaultAsync<UserBasicInfo>(sql, new { Email = email });

        return result;
    }

    public async Task<bool> IsUserExistsAsync(string email)
    {
        string sql = @"SELECT Email, Username FROM AppUsers WHERE Email = @Email";
        var result = await _dbConnection.QueryAsync(sql, new { Email = email });

        return result.Any();
    }

    public async Task<bool> IsValidPassword(string email, string hashedPassword)
    {
        string sql = $"""
            SELECT {nameof(AppUser.HashedPassword)} 
            FROM AppUsers 
            WHERE {nameof(AppUser.Email)} = @Email AND {nameof(AppUser.HashedPassword)} = @HashedPassword
            """;

        var result = await _dbConnection.QueryFirstOrDefaultAsync<string>(sql, new { Email = email, HashedPassword = hashedPassword });

        return result is not null;
    }
}
