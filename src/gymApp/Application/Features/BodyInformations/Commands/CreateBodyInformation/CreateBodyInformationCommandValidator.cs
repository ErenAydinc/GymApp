using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Commands.CreateBodyInformation
{
    public class CreateBodyInformationCommandValidator:AbstractValidator<CreateBodyInformationCommand>
    {
        public CreateBodyInformationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
