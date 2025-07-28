using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.Entities;
using MediatR;

namespace HatChao.Modules.User.Application.Commands;

public class RegisterUserCommandHandler(IUserRepository userRepo, IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, bool>
{
	private readonly IUserRepository _userRepo = userRepo;
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		if (await _userRepo.IsUserExistsAsync(request.Email)) return false;

		var newUser = new AppUser(request.Username, request.Email, request.Password);
		_userRepo.Add(newUser);
		await _unitOfWork.SaveChangesAsync();

		return true;
	}
}
