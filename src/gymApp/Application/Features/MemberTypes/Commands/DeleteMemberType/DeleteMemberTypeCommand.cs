using Application.Features.MemberTypes.Constants;
using Application.Features.MemberTypes.Dtos;
using Application.Features.MemberTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MemberTypes.Commands.DeleteMemberType
{
    public class DeleteMemberTypeCommand:IRequest<DeleteMemberTypeDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            MemberTypeRoles.MemberTypeDelete,
            MemberTypeRoles.MemberTypeAdmin
        };

        public class DeleteMemberTypeCommandHandler : IRequestHandler<DeleteMemberTypeCommand, DeleteMemberTypeDto>
        {
            private readonly IMemberTypeRepository _memberTypeRepository;
            private readonly MemberTypeBusinessRules _memberTypeBusinessRules;
            private readonly IMapper _mapper;

            public DeleteMemberTypeCommandHandler(IMemberTypeRepository memberTypeRepository, MemberTypeBusinessRules memberTypeBusinessRules, IMapper mapper)
            {
                _memberTypeRepository = memberTypeRepository;
                _memberTypeBusinessRules = memberTypeBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteMemberTypeDto> Handle(DeleteMemberTypeCommand request, CancellationToken cancellationToken)
            {
                await _memberTypeBusinessRules.MemberTypeNotExists(request.Id);

                MemberType? memberType = _mapper.Map<MemberType>(request);

                MemberType? mappedMemberType = await _memberTypeRepository.DeleteAsync(memberType);

                DeleteMemberTypeDto deleteMemberTypeDto = _mapper.Map<DeleteMemberTypeDto>(mappedMemberType);

                return deleteMemberTypeDto;
            }
        }
    }
}
