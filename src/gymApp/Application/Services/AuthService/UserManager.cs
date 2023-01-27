using Application.Services.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository? _userRepository;

        public UserManager(IUserRepository? userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GetFullName(int id)
        {
            var userFirstName = (await _userRepository.GetAsync(x => x.Id == id)).FirstName;
            var userLastName = (await _userRepository.GetAsync(x => x.Id == id)).LastName;

            var userFullName = userFirstName + " " + userLastName;

            return userFullName;
        }
    }
}
