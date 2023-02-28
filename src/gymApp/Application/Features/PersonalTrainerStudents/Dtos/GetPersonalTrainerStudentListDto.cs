using Core.Security.Entities;

namespace Application.Features.PersonalTrainerStudents.Dtos
{
    public class GetPersonalTrainerStudentListDto
    {
        public int Id { get; set; }
        public int PersonalTrainerId { get; set; }
        public string PersonalTrainerName { get; set; }
        public int StudentsCount { get; set; }
    }
}
