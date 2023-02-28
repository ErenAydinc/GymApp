using Application.Features.Commons.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Commons.Models
{
    public class CommonStudentListModel:BasePageableModel
    {
        public IList<CommonStudentListDto> Items{ get; set; }
    }
}
