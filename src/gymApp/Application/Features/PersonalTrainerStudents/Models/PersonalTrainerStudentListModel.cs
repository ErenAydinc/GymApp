using Application.Features.PersonalTrainerStudents.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.PersonalTrainerStudents.Models
{
    public class PersonalTrainerStudentListModel: BasePageableModel
    {
        public IList<GetPersonalTrainerStudentListDto> Items { get; set; }
    }
}
