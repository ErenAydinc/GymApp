using Application.Constants;
using Application.Features.PersonalTrainerStudents.Constants;
using Application.Features.PersonalTrainerStudents.Dtos;
using Application.Features.PersonalTrainerStudents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.PersonalTrainerStudents.Commands.CreatePersonalTrainerStudent
{
    public class CreatePersonalTrainerStudentCommand:IRequest<CreatePersonalTrainerStudentDto>,ISecuredRequest
    {
        public int StudentId { get; set; }
        public int PersonalTrainerId { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin
        };


        public class CreatePersonalTrainerStudentCommandHandler : IRequestHandler<CreatePersonalTrainerStudentCommand, CreatePersonalTrainerStudentDto>
        {
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly PersonalTrainerStudentBusinessRules _personalTrainerStudentBusinessRules;
            private readonly IMapper _mapper;
            public CreatePersonalTrainerStudentCommandHandler(IPersonalTrainerStudentRepository personalTrainerStudentRepository, PersonalTrainerStudentBusinessRules personalTrainerStudentBusinessRules, IMapper mapper)
            {
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
                _personalTrainerStudentBusinessRules = personalTrainerStudentBusinessRules;
                _mapper = mapper;
            }
            public async Task<CreatePersonalTrainerStudentDto> Handle(CreatePersonalTrainerStudentCommand request, CancellationToken cancellationToken)
            {
                await _personalTrainerStudentBusinessRules.StudentAlreadyExist(request.StudentId);

                PersonalTrainerStudent? personalTrainerStudent = _mapper.Map<PersonalTrainerStudent>(request);

                PersonalTrainerStudent mappedPersonalTrainerStudent = await _personalTrainerStudentRepository.AddAsync(personalTrainerStudent);

                CreatePersonalTrainerStudentDto createPersonalTrainerStudentDto = _mapper.Map<CreatePersonalTrainerStudentDto>(mappedPersonalTrainerStudent);

                return createPersonalTrainerStudentDto;
            }
        }
    }
}
