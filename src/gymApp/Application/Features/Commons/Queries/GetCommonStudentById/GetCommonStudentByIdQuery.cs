using Application.Features.Commons.Dtos;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Queries.GetCommonStudentById
{
    public class GetCommonStudentByIdQuery:IRequest<CommonStudentByIdDto>
    {
        public int Id { get; set; } = 0;


        public class GetCommonStudentByIdQueryHandler : IRequestHandler<GetCommonStudentByIdQuery, CommonStudentByIdDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IBodyInformationRepository _bodyInformationRepository;
            private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
            private readonly IHelperService _helperService;
            private readonly IMapper _mapper;

            public GetCommonStudentByIdQueryHandler(IUserRepository userRepository, IBodyInformationRepository bodyInformationRepository, IHelperService helperService, IMapper mapper, IPersonalTrainerStudentRepository personalTrainerStudentRepository)
            {
                _userRepository = userRepository;
                _bodyInformationRepository = bodyInformationRepository;
                _helperService = helperService;
                _mapper = mapper;
                _personalTrainerStudentRepository = personalTrainerStudentRepository;
            }

            public async Task<CommonStudentByIdDto> Handle(GetCommonStudentByIdQuery request, CancellationToken cancellationToken)
            {
                int userId = 0;

                if (request.Id<=0)
                {
                   userId = await _helperService.CurrentUser();
                }

                User? user = await _userRepository.GetAsync(x => x.Id == (request.Id <=0 ? userId :request.Id));
                BodyInformation? bodyInformation = await _bodyInformationRepository.GetAsync(x=>x.UserId == (request.Id <= 0 ? userId : request.Id));

                string? needProtein = null;
                string? needWater = null;
                if (request.Id<=0 && bodyInformation !=null)
                {
                    needProtein = (bodyInformation.Weight * 0.8).ToString() + "-" + (bodyInformation.Weight * 1).ToString();
                    needWater = (bodyInformation.Weight * 0.03).ToString();
                    //var needCalori =( (66 + (13.7 * bodyInformation.Weight) )+ (5 * bodyInformation.Length) - (6.8 * 22));
                }

                string? personalTrainerName = null;
                string? personalTrainerEmail = null;
                if (request.Id <= 0)
                {
                    PersonalTrainerStudent? personalTrainerStudent = await _personalTrainerStudentRepository.GetAsync(x => x.StudentId == userId);
                    personalTrainerName = (await _helperService.FullName(personalTrainerStudent.PersonalTrainerId));
                    personalTrainerEmail = (await _userRepository.GetAsync(x => x.Id == personalTrainerStudent.PersonalTrainerId)).Email;
                }

                CommonStudentByIdDto dto = new CommonStudentByIdDto()
                {
                    Id = user.Id,
                    FullName = await _helperService.FullName(user.Id),
                    Email = user.Email,
                    PersonalTrainerName = request.Id <= 0 ? personalTrainerName : null,
                    PersonalTrainerEmail = request.Id<=0 ? personalTrainerEmail : null,
                    DailyNeedProtein = needProtein,
                    DailyNeedWater = needWater,
                    BodyInformationId = bodyInformation==null ?0 : bodyInformation.Id,
                    Arm =bodyInformation==null ?0:  bodyInformation.Arm,
                    Chest = bodyInformation == null ? 0 : bodyInformation.Chest,
                    Leg = bodyInformation == null ? 0 : bodyInformation.Leg,
                    Length = bodyInformation == null ? 0 : bodyInformation.Length,
                    Shoulder = bodyInformation == null ? 0 : bodyInformation.Shoulder,
                    Weight = bodyInformation == null ? 0 : bodyInformation.Weight
                };

                CommonStudentByIdDto commonStudentByIdDto = _mapper.Map<CommonStudentByIdDto>(dto);

                return commonStudentByIdDto;
            }
        }
    }
}
