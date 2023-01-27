using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Dtos
{
    public class GetBodyInformationListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Arm { get; set; }
        public float Shoulder { get; set; }
        public float Leg { get; set; }
        public float Chest { get; set; }        
    }
}
