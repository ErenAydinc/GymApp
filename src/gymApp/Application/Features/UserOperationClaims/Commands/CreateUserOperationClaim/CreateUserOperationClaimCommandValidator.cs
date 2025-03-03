﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandValidator:AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.OperationClaimIds).NotEmpty();
        }
    }
}
