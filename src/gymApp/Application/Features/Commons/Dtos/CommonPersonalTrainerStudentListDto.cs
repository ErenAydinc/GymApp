using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Dtos
{
    public class CommonPersonalTrainerStudentListDto
    {
        public int StudentId { get; set; }
        public int PersonalTrainerId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentEmail { get; set; }
    }
}
