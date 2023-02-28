using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsersMovement:Entity
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

        public UsersMovement()
        {

        }

        public UsersMovement(int userId, int movementId, int setNumber, int repetitionNumber, int weight, bool isMonday, bool isTuesday, bool isWednesday, bool isThursday, bool isFriday, bool isSaturday, bool isSunday)
        {
            UserId = userId;
            MovementId = movementId;
            SetNumber = setNumber;
            RepetitionNumber = repetitionNumber;
            Weight = weight;
            IsMonday = isMonday;
            IsTuesday = isTuesday;
            IsWednesday = isWednesday;
            IsThursday = isThursday;
            IsFriday = isFriday;
            IsSaturday = isSaturday;
            IsSunday = isSunday;
        }
    }
}
