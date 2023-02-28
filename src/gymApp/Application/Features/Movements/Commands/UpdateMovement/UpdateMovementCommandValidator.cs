using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Commands.UpdateMovement
{
    public class UpdateMovementCommandValidator:AbstractValidator<UpdateMovementCommand>
    {
        public UpdateMovementCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.Id).NotNull();
        }
    }
}
