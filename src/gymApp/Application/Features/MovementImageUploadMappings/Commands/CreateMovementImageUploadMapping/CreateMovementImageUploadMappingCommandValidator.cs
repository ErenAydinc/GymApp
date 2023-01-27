using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MovementImageUploadMappings.Commands.CreateMovementImageUploadMapping
{
    public class CreateMovementImageUploadMappingCommandValidator : AbstractValidator<CreateMovementImageUploadMappingCommand>
    {
        public CreateMovementImageUploadMappingCommandValidator()
        {
            RuleFor(x => x.ImageUploadId).NotNull();
            RuleFor(x => x.MovementId).NotNull();
        }
    }
}
