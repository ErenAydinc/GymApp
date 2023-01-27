using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
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

        public async Task IdIsNotExists(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (user == null) throw new BusinessException("Id is not exists");
        }

        public void UserShouldExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("Requested user does not exist");
        }
    }
}
