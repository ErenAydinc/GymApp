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

namespace Application.Features.PersonalTrainerStudents.Commands.DeletePersonalTrainerStudent
{
    public class DeletePersonalTrainerStudentCommand:IRequest<DeletePersonalTrainerStudentDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin
        };


        public class DeletePersonalTrainerStudentCommandHandler : IRequestHandler<DeletePersonalTrainerStudentCommand, DeletePersonalTrainerStudentDto>
        {
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly PersonalTrainerStudentBusinessRules _personalTrainerStudentBusinessRules;
            private readonly IMapper _mapper;

            public DeletePersonalTrainerStudentCommandHandler(IPersonalTrainerStudentRepository personalTrainerStudentRepository, PersonalTrainerStudentBusinessRules personalTrainerStudentBusinessRules, IMapper mapper)
            {
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
                _personalTrainerStudentBusinessRules = personalTrainerStudentBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeletePersonalTrainerStudentDto> Handle(DeletePersonalTrainerStudentCommand request, CancellationToken cancellationToken)
            {
                await _personalTrainerStudentBusinessRules.PersonalTrainerStudentNotExists(request.Id);

                PersonalTrainerStudent? personalTrainerStudent = _mapper.Map<PersonalTrainerStudent>(request);

                PersonalTrainerStudent? mappedPersonalTrainerStudent = await _personalTrainerStudentRepository.DeleteAsync(personalTrainerStudent);

                DeletePersonalTrainerStudentDto deletePersonalTrainerStudentDto = _mapper.Map<DeletePersonalTrainerStudentDto>(mappedPersonalTrainerStudent);

                return deletePersonalTrainerStudentDto;
            }
        }
    }
}
