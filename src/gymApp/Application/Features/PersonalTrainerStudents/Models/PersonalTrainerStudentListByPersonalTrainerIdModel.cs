using Application.Features.PersonalTrainerStudents.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.PersonalTrainerStudents.Models
{
    public class PersonalTrainerStudentListByPersonalTrainerIdModel: BasePageableModel
    {
        public IList<GetPersonalTrainerStudentListByPersonalTrainerIdDto> Items { get; set; }
    }
}
