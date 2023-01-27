using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Commands.DeleteMovement
{
    public class DeleteMovementCommandValidator:AbstractValidator<DeleteMovementCommand>
    {
        public DeleteMovementCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
