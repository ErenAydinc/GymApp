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

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public bool Status { get; set; }
        public int Type { get; set; }
        public int TimeZone { get; set; }
        public DateTime? MemberStartDate { get; set; }
        public DateTime? MemberEndDate { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
        {
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public UpdateUserCommandHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IMapper mapper, IHelperService helperService)
            {
                _userBusinessRules = userBusinessRules;
                _userRepository = userRepository;
                _mapper = mapper;
                _helperService = helperService;
            }

            public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.IdIsNotExists(request.Id);
                var updateUser = await _userRepository.GetAsync(x => x.Id == request.Id);
                User updtUser = new()
                {
                    Id = request.Id,
                    Email = request.Email,
                    PasswordHash = updateUser.PasswordHash,
                    PasswordSalt = updateUser.PasswordSalt,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    CustomerId = await _helperService.CurrentCustomer(),
                    CompanyId = await _helperService.CurrentCompany(),
                    Status = request.Status,
                    Type=request.Type,
                    TimeZone=1,
                    MemberStartDate=updateUser.MemberStartDate,
                    MemberEndDate=request.MemberEndDate!=null?request.MemberEndDate:updateUser.MemberEndDate
                };
                User mappedUser = _mapper.Map<User>(updtUser);

                User updatedUser = await _userRepository.UpdateAsync(updtUser);

                UpdateUserDto updateUserDto = _mapper.Map<UpdateUserDto>(updatedUser);

                return updateUserDto;

            }
        }
    }
}
