using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UsersMovements.Commands.UpdateUsersMovement
{
    public class UpdateUsersMovementCommandValidator:AbstractValidator<UpdateUsersMovementCommand>
    {
        public UpdateUsersMovementCommandValidator()
        {
            RuleFor(x=>x.Id).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.MovementId).NotNull();
            RuleFor(x => x.SetNumber).NotNull();
            RuleFor(x => x.RepetitionNumber).NotNull();
        }
    }
}
