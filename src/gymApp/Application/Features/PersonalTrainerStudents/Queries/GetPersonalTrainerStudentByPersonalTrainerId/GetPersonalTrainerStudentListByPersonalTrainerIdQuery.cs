using Application.Constants;
using Application.Features.PersonalTrainerStudents.Constants;
using Application.Features.PersonalTrainerStudents.Models;
using Application.Features.PersonalTrainerStudents.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentByPersonalTrainerId
{
    public class GetPersonalTrainerStudentListByPersonalTrainerIdQuery:IRequest<PersonalTrainerStudentListByPersonalTrainerIdModel>,ISecuredRequest
    {
        public string? SearchStudentFirstName { get; set; }
        public string? SearchStudentLastName { get; set; }
        public int PersonalTrainerId { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };
        public class GetPersonalTrainerStudentListByPersonalTrainerIdQueryHandler : IRequestHandler<GetPersonalTrainerStudentListByPersonalTrainerIdQuery, PersonalTrainerStudentListByPersonalTrainerIdModel>
        {
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly IHelperService _helperService;
            private readonly IUserRepository _userRepository;
            private readonly PersonalTrainerStudentBusinessRules _personalTrainerStudentBusinessRules;
            private readonly IMapper _mapper;

            public GetPersonalTrainerStudentListByPersonalTrainerIdQueryHandler(IPersonalTrainerStudentRepository personalTrainerStudentRepository, PersonalTrainerStudentBusinessRules personalTrainerStudentBusinessRules, IMapper mapper, IHelperService helperService, IUserRepository userRepository)
            {
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
                _personalTrainerStudentBusinessRules = personalTrainerStudentBusinessRules;
                _mapper = mapper;
                _helperService = helperService;
                _userRepository = userRepository;
            }

            public async Task<PersonalTrainerStudentListByPersonalTrainerIdModel> Handle(GetPersonalTrainerStudentListByPersonalTrainerIdQuery request, CancellationToken cancellationToken)
            {
                await _personalTrainerStudentBusinessRules.PersonalTrainerNotExist(request.PersonalTrainerId);
                IPaginate<PersonalTrainerStudent> personalTrainerStudent = await _personalTrainerStudentRepository.GetListAsync(predicate:x=>x.PersonalTrainerId==request.PersonalTrainerId,index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                PersonalTrainerStudentListByPersonalTrainerIdModel personalTrainerStudentListByPersonalTrainerIdModel =_mapper.Map<PersonalTrainerStudentListByPersonalTrainerIdModel>(personalTrainerStudent);

                foreach (var personalTrainerStudentListByPersonalTrainerId in personalTrainerStudentListByPersonalTrainerIdModel.Items)
                {
                    personalTrainerStudentListByPersonalTrainerId.StudentId = personalTrainerStudentListByPersonalTrainerId.StudentId;
                    User? user = await _userRepository.GetAsync(x => x.Id == personalTrainerStudentListByPersonalTrainerId.StudentId);
                    personalTrainerStudentListByPersonalTrainerId.StudentFirstName = user.FirstName;
                    personalTrainerStudentListByPersonalTrainerId.StudentLastName = user.LastName;
                    personalTrainerStudentListByPersonalTrainerId.StudentEmail = user.Email;
                }

                return personalTrainerStudentListByPersonalTrainerIdModel;
            }
        }
    }
}
