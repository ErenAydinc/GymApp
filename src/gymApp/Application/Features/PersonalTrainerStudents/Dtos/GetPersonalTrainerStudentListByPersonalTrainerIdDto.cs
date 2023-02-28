using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainerStudents.Dtos
{
    public class GetPersonalTrainerStudentListByPersonalTrainerIdDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNumber { get; set; }
        public int PersonalTrainerId { get; set; }
    }
}
