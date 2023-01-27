using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MemberTypes.Commands.CreateMemberType
{
    public class CreateMemberTypeCommandValidator : AbstractValidator<CreateMemberTypeCommand>
    {
        public CreateMemberTypeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
