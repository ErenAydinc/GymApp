using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand:IRequest<LoggedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly IRefreshTokenRepository _refreshTokenRepository;
            public LoginCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService, IRefreshTokenRepository refreshTokenRepository)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
                _refreshTokenRepository = refreshTokenRepository;
            }

            public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailIsNotExists(request.UserForLoginDto.Email);
                
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                await _authBusinessRules.VerifyMemberPassword(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
                IPaginate<RefreshToken> refreshToken = await _refreshTokenRepository.GetListAsync(x => x.UserId == user.Id);
                foreach (var item in refreshToken.Items)
                {
                    RefreshToken deleteLastRefreshToken = await _refreshTokenRepository.DeleteAsync(item);
                }
                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoggedDto loggedDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken
                };
                return loggedDto;

            }
        }
    }
}