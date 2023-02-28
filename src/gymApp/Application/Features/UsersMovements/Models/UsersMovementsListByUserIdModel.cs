using Application.Features.UsersMovements.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UsersMovements.Models
{
    public class UsersMovementsListByUserIdModel:BasePageableModel
    {
        public IList<GetUsersMovementsByUserIdDto> Items { get; set; }
    }
}
