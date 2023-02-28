using Application.Constants;
using Application.Features.PersonalTrainerStudents.Models;
using Application.Features.PersonalTrainerStudents.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentList
{
    public class GetPersonalTrainerStudentListQuery : IRequest<PersonalTrainerStudentListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
            GeneralRoles.PersonalTrainer
        };

        public class GetPersonalTrainerStudentListQueryHandler : IRequestHandler<GetPersonalTrainerStudentListQuery, PersonalTrainerStudentListModel>
        {
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly IUserRepository _userRepository;
            private readonly IHelperService _helperService;
            private readonly PersonalTrainerStudentBusinessRules _personalTrainerStudentBusinessRules;
            private readonly IMapper _mapper;

            public GetPersonalTrainerStudentListQueryHandler(IPersonalTrainerStudentRepository personalTrainerStudentRepository, PersonalTrainerStudentBusinessRules personalTrainerStudentBusinessRules, IMapper mapper, IUserRepository userRepository, IHelperService helperService)
            {
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
                _personalTrainerStudentBusinessRules = personalTrainerStudentBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
                _helperService = helperService;
            }

            public async Task<PersonalTrainerStudentListModel> Handle(GetPersonalTrainerStudentListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<PersonalTrainerStudent> personalTrainerStudent = await _personalTrainerStudentRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);
                PersonalTrainerStudentListModel mappedPersonalTrainerStudentListModel = _mapper.Map<PersonalTrainerStudentListModel>(personalTrainerStudent);
                foreach (var mappedPersonalTrainerStudent in mappedPersonalTrainerStudentListModel.Items.GroupBy(x=>x.PersonalTrainerId).Select(x=>x.First()))
                {
                    mappedPersonalTrainerStudent.PersonalTrainerName = await _helperService.FullName(mappedPersonalTrainerStudent.PersonalTrainerId);
                    mappedPersonalTrainerStudent.PersonalTrainerId = mappedPersonalTrainerStudent.PersonalTrainerId;
                    var studentCount = await _personalTrainerStudentRepository.GetAllAsync(x => x.PersonalTrainerId == mappedPersonalTrainerStudent.PersonalTrainerId);
                    mappedPersonalTrainerStudent.StudentsCount = studentCount.Count;
                }
                var nullPersonalTrainerStudent = mappedPersonalTrainerStudentListModel.Items.Where(x => x.PersonalTrainerName == null);
                if (nullPersonalTrainerStudent!=null)
                {
                    var removeItem = mappedPersonalTrainerStudentListModel.Items.Where(x => x.PersonalTrainerName == null);
                    foreach (var item in removeItem.ToList())
                    {
                        mappedPersonalTrainerStudentListModel.Items.Remove(item);
                    }
                }
                
                return mappedPersonalTrainerStudentListModel;
            }
        }
    }
}
