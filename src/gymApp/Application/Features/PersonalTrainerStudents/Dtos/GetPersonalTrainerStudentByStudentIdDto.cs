using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainerStudents.Dtos
{
    public class GetPersonalTrainerStudentByStudentIdDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PersonalTrainerId { get; set; }
    }
}
