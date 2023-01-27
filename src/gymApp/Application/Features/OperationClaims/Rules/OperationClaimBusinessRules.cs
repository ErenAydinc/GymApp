using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimAlreadyExists(string name)
        {
            OperationClaim? operationClaim= await _operationClaimRepository.GetAsync(x => x.Name == name);

            if (operationClaim != null) throw new BusinessException("Operation claim already exists");
        }

        public async Task OperationClaimNotExists(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == id);

            if (operationClaim == null) throw new BusinessException("Operation claim not exists");
        }
    }
}
