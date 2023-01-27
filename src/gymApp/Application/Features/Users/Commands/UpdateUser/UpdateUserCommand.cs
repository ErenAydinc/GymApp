using Application.Features.Auths.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
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
    public class UpdateUserCommand : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
        {
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UpdateUserCommandHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IMapper mapper)
            {
                _userBusinessRules = userBusinessRules;
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.IdIsNotExists(request.Id);
                await _userBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.Email);
                var updateUser = await _userRepository.GetAsync(x => x.Id == request.Id);
                User updtUser = new()
                {
                    Id = request.Id,
                    Email = request.Email,
                    PasswordHash = updateUser.PasswordHash,
                    PasswordSalt = updateUser.PasswordSalt,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Status = request.Status==null ? true  : false
                };
                User mappedUser = _mapper.Map<User>(updtUser);

                User updatedUser = await _userRepository.UpdateAsync(updtUser);

                UpdateUserDto updateUserDto = _mapper.Map<UpdateUserDto>(updatedUser);

                return updateUserDto;

            }
        }
    }
}
