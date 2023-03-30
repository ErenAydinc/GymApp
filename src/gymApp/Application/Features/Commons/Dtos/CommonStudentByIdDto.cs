using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Dtos
{
    public class CommonStudentByIdDto
    {
        public int Id { get; set; }
        public int BodyInformationId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PersonalTrainerName { get; set; }
        public string? PersonalTrainerEmail { get; set; }
        public string? DailyNeedProtein { get; set; }
        public string? DailyNeedWater { get; set; }
        public float? Length { get; set; }
        public float? Weight { get; set; }
        public float? Arm { get; set; }
        public float? Shoulder { get; set; }
        public float? Leg { get; set; }
        public float? Chest { get; set; }
    }
}
