using HatChao.Modules.User.Domain.Entities;

namespace HatChao.Modules.User.Application.Interfaces;

public interface IUserRepository : IBaseRepository<AppUser>
{
	Task<bool> IsUserExistsAsync(string email);
}
