using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Commands.DeleteBodyInformation
{
    public class DeleteBodyInformationCommandValidator:AbstractValidator<DeleteBodyInformationCommand>
    {
        public DeleteBodyInformationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
