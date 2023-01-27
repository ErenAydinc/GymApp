using Application.Features.Auths.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<RegisteredDto>
    {
        public CreateUserDto CreateUserDto { get; set; }
        public string IpAddress { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisteredDto>
        {
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public CreateUserCommandHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _userBusinessRules = userBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.CreateUserDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.CreateUserDto.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    Email = request.CreateUserDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.CreateUserDto.FirstName,
                    LastName = request.CreateUserDto.LastName,
                    Status = true
                };

                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken,
                };
                return registeredDto;

            }
        }
    }
}
