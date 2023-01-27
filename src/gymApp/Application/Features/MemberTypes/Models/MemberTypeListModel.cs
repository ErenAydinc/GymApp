using Application.Features.MemberTypes.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.MemberTypes.Models
{
    public class MemberTypeListModel: BasePageableModel
    {
        public IList<GetMemberTypeListDto> Items { get; set; }
    }
}
