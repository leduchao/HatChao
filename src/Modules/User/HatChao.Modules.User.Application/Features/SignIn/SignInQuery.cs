using FluentValidation;
using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.DTOs;
using HatChao.Modules.User.Application.Errors;
using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.ValueObjects;
using MediatR;

namespace HatChao.Modules.User.Application.Features.SignIn;

public record SignInQuery(string Email, string Password) : IRequest<Result<UserInfo>>;

public class SignInQueryHandler : IRequestHandler<SignInQuery, Result<UserInfo>>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<SignInQuery> _validator;

    public SignInQueryHandler(IUserRepository userRepository, IValidator<SignInQuery> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<Result<UserInfo>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<UserInfo>.Failure(new Error("SignInUser", validationResult.ToString()));
        }

        if (!await _userRepository.IsUserExistsAsync(request.Email))
            return Result<UserInfo>.Failure(AuthError.UserNotFound);

        var passwordHash = PasswordHash.Create(request.Password, request.Email);
        if (!await _userRepository.IsValidPassword(request.Email, passwordHash.HashedValue))
            return Result<UserInfo>.Failure(AuthError.PasswordIncorrect);

        var userInfo = await _userRepository.GetUserInforAsync(request.Email);
        return Result<UserInfo>.Success(userInfo);
    }
}
