using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;
using Domain.MappingEntities;

namespace Application.Features.PersonalTrainerStudents.Rules
{
    public class PersonalTrainerStudentBusinessRules
    {
        private readonly IPersonalTrainerStudentRepository _personalTrainerStudentRepository;
        private readonly IUserRepository _userRepository;
        public PersonalTrainerStudentBusinessRules(IPersonalTrainerStudentRepository personalTrainerStudentRepository, IUserRepository userRepository)
        {
            _personalTrainerStudentRepository = personalTrainerStudentRepository;
            _userRepository = userRepository;
        }

        public async Task PersonalTrainerStudentNotExists(int personalTrainerStudentId)
        {
            PersonalTrainerStudent? personalTrainerStudent = await _personalTrainerStudentRepository.GetAsync(x => x.Id == personalTrainerStudentId);

            if (personalTrainerStudent == null) throw new BusinessException("Personal trainer student not exists");
        }

        public async Task StudentAlreadyExist(int userId)
        {
            PersonalTrainerStudent personalTrainerStudent = await _personalTrainerStudentRepository.GetAsync(x => x.Id == userId);
            if (personalTrainerStudent != null) throw new BusinessException("Student already exist");
        }

        public async Task StudentNotExists(int userId)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == userId);
            if (user == null) throw new BusinessException("Student not exists");
        }

        public async Task PersonalTrainerNotExist(int personalTrainerId)
        {
            User? personalTrainer= await _userRepository.GetAsync(x => x.Id == personalTrainerId && x.Type ==2);
            if (personalTrainer == null) throw new BusinessException("Personal trainer not exists");
        }

    }
}
