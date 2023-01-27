using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Commands.UpdateBodyInformation
{
    public class UpdateBodyInformationCommandValidator:AbstractValidator<UpdateBodyInformationCommand>
    {
        public UpdateBodyInformationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
