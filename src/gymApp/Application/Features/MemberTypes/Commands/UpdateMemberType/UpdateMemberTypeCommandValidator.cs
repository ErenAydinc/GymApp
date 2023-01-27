using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MemberTypes.Commands.UpdateMemberType
{
    public class UpdateMemberTypeCommandValidator:AbstractValidator<UpdateMemberTypeCommand>
    {
        public UpdateMemberTypeCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
