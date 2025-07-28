namespace HatChao.Modules.User.Application.Interfaces;

public interface IUnitOfWork
{
	Task<int> SaveChangesAsync();
}
