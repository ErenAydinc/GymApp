using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Dtos
{
    public class CommonStudentMovementListByStudentIdAndSelectedDayDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int MovementId { get; set; }
        public string MovementName { get; set; }
        public int SetNumber { get; set; }
        public int RepetitionNumber { get; set; }
        public int Weight { get; set; }
    }
}
