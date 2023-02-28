using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UsersMovements.Dtos
{
    public class CreateUsersMovementDto
    {
        public int UserId { get; set; }
        public int MovementId { get; set; }
        public int SetNumber { get; set; }
        public int RepetitionNumber { get; set; }
        public int Weight { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsSunday { get; set; }
    }
}
