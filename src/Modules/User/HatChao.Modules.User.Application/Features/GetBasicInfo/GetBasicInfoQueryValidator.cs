using FluentValidation;

namespace HatChao.Modules.User.Application.Features.GetBasicInfo;

public class GetBasicInfoQueryValidator : AbstractValidator<GetBasicInfoQuery>
{
    public GetBasicInfoQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
