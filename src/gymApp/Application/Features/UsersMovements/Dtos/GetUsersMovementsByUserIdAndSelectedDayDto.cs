using Domain.Entities;

namespace Application.Features.UsersMovements.Dtos
{
    public class GetUsersMovementsByUserIdAndSelectedDayDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MovementId { get; set; }
        public string MovementName { get; set; }
        public ICollection<MovementImage> MovementImage { get; set; }
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
