using Application.Features.Movements.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Movements.Models
{
    public class MovementListModel : BasePageableModel
    {
        public IList<GetMovementListDto> Items { get; set; }
    }
}
