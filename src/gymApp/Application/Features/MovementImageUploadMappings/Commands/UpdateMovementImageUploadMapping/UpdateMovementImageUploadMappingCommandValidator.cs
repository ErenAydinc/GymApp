using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MovementImageUploadMappings.Commands.UpdateMovementImageUploadMapping
{
    public class UpdateMovementImageUploadMappingCommandValidator:AbstractValidator<UpdateMovementImageUploadMappingCommand>
    {
        public UpdateMovementImageUploadMappingCommandValidator()
        {
            RuleFor(x=>x.Id).NotNull();
            RuleFor(x => x.ImageUploadId).NotNull();
            RuleFor(x => x.MovementId).NotNull();
        }
    }
}
