using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task UserOperationClaimNotExists(int id)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == id);

            if (userOperationClaim == null) throw new BusinessException("User operation claim not exists");
        }

        public async Task UserNotExists(int userId)
        {
            User? user =  await _userRepository.GetAsync(x => x.Id == userId);

            if (user == null) throw new BusinessException("User not exists");
        }

        public async Task OperationClaimNotExists(int operationClaimId)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == operationClaimId);

            if (operationClaim == null) throw new BusinessException("Operation claim not exists");
        }
    }
}
