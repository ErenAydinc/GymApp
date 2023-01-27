using FluentValidation;

namespace Application.Features.UserMemberTypeMappings.Commands.CreateUserMemberTypeMapping
{
    public class CreateUserMemberTypeMappingCommandValidator : AbstractValidator<CreateUserMemberTypeMappingCommand>
    {
        public CreateUserMemberTypeMappingCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.MemberTypeId).NotNull();
        }
    }
}
