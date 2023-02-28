using Application.Features.UsersMovements.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UsersMovements.Models
{
    public class UsersMovementListModel : BasePageableModel
    {
        public IList<GetUsersMovementListDto> Items { get; set; }
    }
}
