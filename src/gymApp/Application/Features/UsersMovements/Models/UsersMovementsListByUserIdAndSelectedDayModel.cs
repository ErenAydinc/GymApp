using Application.Features.UsersMovements.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UsersMovements.Models
{
    public class UsersMovementsListByUserIdAndSelectedDayModel:BasePageableModel
    {
        public IList<GetUsersMovementsByUserIdAndSelectedDayDto> Items { get; set; }
    }
}
