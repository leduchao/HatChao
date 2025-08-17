using FluentValidation;
using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.DTOs;
using HatChao.Modules.User.Application.Interfaces;
using MediatR;

namespace HatChao.Modules.User.Application.Features.GetBasicInfo;

public record GetBasicInfoQuery(string Email) : IRequest<Result<UserBasicInfo>>;

public class GetBasicInfoQueryHandler : IRequestHandler<GetBasicInfoQuery, Result<UserBasicInfo>>
{
    private readonly IUserRepository _userRepo;
    private readonly IValidator<GetBasicInfoQuery> _validator;

    public GetBasicInfoQueryHandler(IUserRepository userRepo, IValidator<GetBasicInfoQuery> validator)
    {
        _userRepo = userRepo;
        _validator = validator;
    }

    public async Task<Result<UserBasicInfo>> Handle(GetBasicInfoQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Result<UserBasicInfo>.Failure(new Error("GetUserBasicInfoValidation", validationResult.ToString()));
        }

        var userInfo = await _userRepo.GetUserInforAsync(request.Email);
        return Result<UserBasicInfo>.Success(userInfo);
    }
}
