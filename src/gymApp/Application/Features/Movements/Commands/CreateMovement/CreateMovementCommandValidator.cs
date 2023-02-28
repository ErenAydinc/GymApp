using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Commands.CreateMovement
{
    public class CreateMovementCommandValidator:AbstractValidator<CreateMovementCommand>
    {
        public CreateMovementCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).NotNull();
        }
    }
}
