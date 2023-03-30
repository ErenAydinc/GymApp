using Application.Constants;
using Application.Features.Auths.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Helpers;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Extensions;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.MappingEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<RegisteredDto>, ISecuredRequest
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisteredDto>
        {
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IAuthService authService, IHttpContextAccessor httpContextAccessor, IMapper mapper, IHelperService helperService)
            {
                _userBusinessRules = userBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
                _httpContextAccessor = httpContextAccessor;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<RegisteredDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    CustomerId =request.UserForRegisterDto.CustomerId==null? await _helperService.CurrentCustomer(): request.UserForRegisterDto.CustomerId,
                    CompanyId = await _helperService.CurrentCompany(),
                    Status = true,
                    Type = request.UserForRegisterDto.Type,
                    TimeZone = 1,
                    MemberStartDate = request.UserForRegisterDto.MemberStartDate!=null?request.UserForRegisterDto.MemberStartDate:DateTime.UtcNow,
                    MemberEndDate = request.UserForRegisterDto.MemberEndDate!=null ? request.UserForRegisterDto.MemberEndDate : null
                };

                User createdUser = await _userRepository.AddAsync(newUser);
                request.UserForRegisterDto.Id = createdUser.Id;
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
