using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.DTOs;
using HatChao.Modules.User.Application.Errors;
using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.ValueObjects;
using MediatR;

namespace HatChao.Modules.User.Application.Queries;

public class SignInQueryHandler(IUserRepository userRepository) : IRequestHandler<SignInQuery, Result<UserInfo>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<UserInfo>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsUserExistsAsync(request.Email))
            return Result<UserInfo>.Failure(AuthError.UserNotFound);

        var passwordHash = PasswordHash.Create(request.Password, request.Email);
        if (!await _userRepository.IsValidPassword(request.Email, passwordHash.HashedValue))
            return Result<UserInfo>.Failure(AuthError.PasswordIncorrect);

        var userInfo = await _userRepository.GetUserInforAsync(request.Email);
        return Result<UserInfo>.Success(userInfo);
    }
}
