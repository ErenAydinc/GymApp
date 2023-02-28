using FluentValidation;

namespace Application.Features.UsersMovements.Commands.CreateUsersMovement
{
    public class CreateUsersMovementCommandValidator : AbstractValidator<CreateUsersMovementCommand>
    {
        public CreateUsersMovementCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.MovementId).NotNull();
            RuleFor(x=>x.SetNumber).NotNull();
            RuleFor(x => x.RepetitionNumber).NotNull();
        }
    }
}
