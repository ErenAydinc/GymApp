using Application.Features.Categories.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<GetCategoryListDto> Items { get; set; }
    }
}
