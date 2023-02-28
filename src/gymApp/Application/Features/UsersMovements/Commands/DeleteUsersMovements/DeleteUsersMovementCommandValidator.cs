using FluentValidation;

namespace Application.Features.UsersMovements.Commands.DeleteUsersMovement
{
    public class DeleteUsersMovementCommandValidator:AbstractValidator<DeleteUsersMovementCommand>
    {
        public DeleteUsersMovementCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
