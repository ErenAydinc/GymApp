using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u=>u.Email==email);
            if (user != null) throw new BusinessException("Mail already exists");

        }

        public async Task EmailIsNotExists(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException("Mail is not exists");
        }

        public async Task VerifyMemberPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool verified = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!verified) throw new AuthorizationException("Entered password is wrong");

        }
    }
}
