using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserMemberTypeMappings.Commands.UpdateUserMemberTypeMapping
{
    public class UpdateUserMemberTypeMappingCommandValidator:AbstractValidator<UpdateUserMemberTypeMappingCommand>
    {
        public UpdateUserMemberTypeMappingCommandValidator()
        {
            RuleFor(x=>x.Id).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.MemberTypeId).NotNull();
        }
    }
}
