using FluentValidation;
using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.Errors;
using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Domain.Entities;
using MediatR;

namespace HatChao.Modules.User.Application.Features.SignUp;

public record SignUpCommand(string Username, string Email, string Password) : IRequest<Result>;

public class SingUpCommandHandler : IRequestHandler<SignUpCommand, Result>
{
    private readonly IUserRepository _userRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<SignUpCommand> _validator;

    public SingUpCommandHandler(IUserRepository userRepo, IUnitOfWork unitOfWork, IValidator<SignUpCommand> validator)
    {
        _userRepo = userRepo;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result.Failure(new Error("SignUpUserValidation", validationResult.ToString()));
        }

        if (await _userRepo.IsUserExistsAsync(request.Email))
            return Result.Failure(AuthError.EmailExists);

        var newUser = new AppUser(request.Username, request.Email, request.Password);
        _userRepo.Add(newUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
