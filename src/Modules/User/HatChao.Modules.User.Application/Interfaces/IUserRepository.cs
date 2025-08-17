using HatChao.Modules.User.Application.DTOs;
using HatChao.Modules.User.Domain.Entities;

namespace HatChao.Modules.User.Application.Interfaces;

public interface IUserRepository : IBaseRepository<AppUser>
{
    Task<bool> IsUserExistsAsync(string email);

    Task<UserBasicInfo?> GetUserInforAsync(string email);

    Task<bool> IsValidPassword(string email, string hashedPassword);
}
