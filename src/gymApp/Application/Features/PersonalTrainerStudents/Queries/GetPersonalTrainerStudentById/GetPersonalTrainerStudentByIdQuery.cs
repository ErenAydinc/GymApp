using Application.Constants;
using Application.Features.PersonalTrainerStudents.Constants;
using Application.Features.PersonalTrainerStudents.Dtos;
using Application.Features.PersonalTrainerStudents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentById
{
    public class GetPersonalTrainerStudentByIdQuery:IRequest<GetPersonalTrainerStudentByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetPersonalTrainerStudentByIdQueryHandler : IRequestHandler<GetPersonalTrainerStudentByIdQuery, GetPersonalTrainerStudentByIdDto>
        {
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly PersonalTrainerStudentBusinessRules _personalTrainerStudentBusinessRules;
            private readonly IMapper _mapper;

            public GetPersonalTrainerStudentByIdQueryHandler(IPersonalTrainerStudentRepository personalTrainerStudentRepository, PersonalTrainerStudentBusinessRules personalTrainerStudentBusinessRules, IMapper mapper)
            {
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
                _personalTrainerStudentBusinessRules = personalTrainerStudentBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetPersonalTrainerStudentByIdDto> Handle(GetPersonalTrainerStudentByIdQuery request, CancellationToken cancellationToken)
            {
                await _personalTrainerStudentBusinessRules.PersonalTrainerStudentNotExists(request.Id);

                PersonalTrainerStudent? personalTrainerStudent = await _personalTrainerStudentRepository.GetAsync(x=>x.Id == request.Id);

                GetPersonalTrainerStudentByIdDto getPersonalTrainerStudentByIdDto=_mapper.Map<GetPersonalTrainerStudentByIdDto>(personalTrainerStudent);

                return getPersonalTrainerStudentByIdDto;
            }
        }
    }
}
