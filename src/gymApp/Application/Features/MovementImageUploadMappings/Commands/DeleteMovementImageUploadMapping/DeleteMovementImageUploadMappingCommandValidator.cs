using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MovementImageUploadMappings.Commands.DeleteMovementImageUploadMapping
{
    public class DeleteMovementImageUploadMappingCommandValidator:AbstractValidator<DeleteMovementImageUploadMappingCommand>
    {
        public DeleteMovementImageUploadMappingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
