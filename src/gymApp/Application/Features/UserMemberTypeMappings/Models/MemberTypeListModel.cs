using Application.Features.UserMemberTypeMappings.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UserMemberTypeMappings.Models
{
    public class UserMemberTypeMappingListModel : BasePageableModel
    {
        public IList<GetUserMemberTypeMappingListDto> Items { get; set; }
    }
}
