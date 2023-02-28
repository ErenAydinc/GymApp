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
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
         {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserDto>
        {
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public DeleteUserCommandHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IMapper mapper, IHelperService helperService)
            {
                _userBusinessRules = userBusinessRules;
                _userRepository = userRepository;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<DeleteUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.IdIsNotExists(request.Id);
                var deleteUser = await _userRepository.GetAsync(x => x.Id == request.Id);
                User user = new()
                {
                    Id = deleteUser.Id,
                    Email = deleteUser.Email,
                    PasswordHash = deleteUser.PasswordHash,
                    PasswordSalt = deleteUser.PasswordSalt,
                    FirstName = deleteUser.FirstName,
                    LastName = deleteUser.LastName,
                    CustomerId = deleteUser.CustomerId,
                    CompanyId = deleteUser.CompanyId,
                    Status = false,
                    Type = deleteUser.Type,
                    TimeZone = 1,
                    MemberStartDate = deleteUser.MemberStartDate,
                    MemberEndDate = deleteUser.MemberEndDate

                };
                User mappedUser = _mapper.Map<User>(user);

                User deletedUser = await _userRepository.UpdateAsync(mappedUser);

                DeleteUserDto deleteUserDto = _mapper.Map<DeleteUserDto>(deletedUser);

                return deleteUserDto;

            }
        }
    }
}
