﻿using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using FluentValidation;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class UpdateOperationClaimCommandValidator:AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
