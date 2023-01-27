using Application.Features.MemberTypes.Dtos;
using Application.Features.MovementImageUploadMappings.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.MovementImageUploadMappings.Models
{
    public class MovementImageUploadMappingListModel: BasePageableModel
    {
        public IList<GetMovementImageUploadMappingListDto> Items { get; set; }
    }
}
