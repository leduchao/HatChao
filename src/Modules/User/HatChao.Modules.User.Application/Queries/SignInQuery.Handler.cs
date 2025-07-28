using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.ValueObjects;
using MediatR;

namespace HatChao.Modules.User.Application.Queries;

public class SignInQueryHandler(IUserRepository userRepository) : IRequestHandler<SignInQuery, bool>
{
	private readonly IUserRepository _userRepository = userRepository;

	public async Task<bool> Handle(SignInQuery request, CancellationToken cancellationToken)
	{
		if (!await _userRepository.IsUserExistsAsync(request.Email)) return false;

		var passwordHash = PasswordHash.Create(request.Password, request.Email);
		return await _userRepository.IsValidPassword(request.Email, passwordHash.HashedValue);
	}
}
