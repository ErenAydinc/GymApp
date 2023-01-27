using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserMemberTypeMappings.Commands.DeleteUserMemberTypeMapping
{
    public class DeleteUserMemberTypeMappingCommandValidator:AbstractValidator<DeleteUserMemberTypeMappingCommand>
    {
        public DeleteUserMemberTypeMappingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
