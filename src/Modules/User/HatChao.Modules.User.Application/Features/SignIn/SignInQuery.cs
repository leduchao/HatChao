using FluentValidation;

using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.DTOs;
using HatChao.Modules.User.Application.Errors;
using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.ValueObjects;

using MediatR;

namespace HatChao.Modules.User.Application.Features.SignIn;

public record SignInQuery(string Email, string Password) : IRequest<Result<UserBasicInfo>>;

public class SignInQueryHandler : IRequestHandler<SignInQuery, Result<UserBasicInfo>>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<SignInQuery> _validator;

    public SignInQueryHandler(IUserRepository userRepository, IValidator<SignInQuery> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<Result<UserBasicInfo>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var error = new Error("SignInUserValidation", validationResult.ToString());
            return Result<UserBasicInfo>.Failure(error, ErrorType.BadRequest);
        }

        if (!await _userRepository.IsUserExistsAsync(request.Email))
        {
            return Result<UserBasicInfo>.Failure(UserError.UserNotFound, ErrorType.NotFound);
        }

        var passwordHash = PasswordHash.Create(request.Password, request.Email);
        if (!await _userRepository.IsValidPassword(request.Email, passwordHash.HashedValue))
        {
            return Result<UserBasicInfo>.Failure(UserError.PasswordIncorrect, ErrorType.BadRequest);
        }

        var userInfo = await _userRepository.GetUserInforAsync(request.Email);
        return Result<UserBasicInfo>.Success(userInfo);
    }
}
