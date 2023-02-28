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

namespace Application.Features.PersonalTrainerStudents.Commands.UpdatePersonalTrainerStudent
{
    public class UpdatePersonalTrainerStudentCommand:IRequest<UpdatePersonalTrainerStudentDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PersonalTrainerId { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin
        };



        public class UpdatePersonalTrainerStudentCommandHandler : IRequestHandler<UpdatePersonalTrainerStudentCommand, UpdatePersonalTrainerStudentDto>
        {
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly PersonalTrainerStudentBusinessRules _personalTrainerStudentBusinessRules;
            private readonly IMapper _mapper;
            public UpdatePersonalTrainerStudentCommandHandler(IPersonalTrainerStudentRepository personalTrainerStudentRepository, PersonalTrainerStudentBusinessRules personalTrainerStudentBusinessRules, IMapper mapper)
            {
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
                _personalTrainerStudentBusinessRules = personalTrainerStudentBusinessRules;
                _mapper = mapper;
            }
            public async Task<UpdatePersonalTrainerStudentDto> Handle(UpdatePersonalTrainerStudentCommand request, CancellationToken cancellationToken)
            {
                await _personalTrainerStudentBusinessRules.PersonalTrainerStudentNotExists(request.Id);
                await _personalTrainerStudentBusinessRules.StudentNotExists(request.StudentId);
                await _personalTrainerStudentBusinessRules.PersonalTrainerNotExist(request.PersonalTrainerId);

                PersonalTrainerStudent? personalTrainerStudent = _mapper.Map<PersonalTrainerStudent>(request);

                PersonalTrainerStudent mappedPersonalTrainerStudent = await _personalTrainerStudentRepository.UpdateAsync(personalTrainerStudent);

                UpdatePersonalTrainerStudentDto updatePersonalTrainerStudentDto = _mapper.Map<UpdatePersonalTrainerStudentDto>(mappedPersonalTrainerStudent);

                return updatePersonalTrainerStudentDto;
            }
        }
    }
}
