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

namespace Application.Features.MemberTypes.Queries.GetMemberTypeById
{
    public class GetMemberTypeByIdQuery:IRequest<GetMemberTypeByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            MemberTypeRoles.MemberTypeRead,
            MemberTypeRoles.MemberTypeAdmin
        };
        public class GetMemberTypeByIdQueryHandler : IRequestHandler<GetMemberTypeByIdQuery, GetMemberTypeByIdDto>
        {
            private readonly IMemberTypeRepository _memberTypeRepository;
            private readonly MemberTypeBusinessRules _memberTypeBusinessRules;
            private readonly IMapper _mapper;

            public GetMemberTypeByIdQueryHandler(IMemberTypeRepository memberTypeRepository, MemberTypeBusinessRules memberTypeBusinessRules, IMapper mapper)
            {
                _memberTypeRepository = memberTypeRepository;
                _memberTypeBusinessRules = memberTypeBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetMemberTypeByIdDto> Handle(GetMemberTypeByIdQuery request, CancellationToken cancellationToken)
            {
                await _memberTypeBusinessRules.MemberTypeNotExists(request.Id);

                MemberType? memberType = await _memberTypeRepository.GetAsync(x=>x.Id == request.Id);

                GetMemberTypeByIdDto getMemberTypeByIdDto=_mapper.Map<GetMemberTypeByIdDto>(memberType);

                return getMemberTypeByIdDto;
            }
        }
    }
}
