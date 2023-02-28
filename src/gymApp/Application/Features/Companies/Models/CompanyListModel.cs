using Application.Features.Companies.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Companies.Models
{
    public class CompanyListModel : BasePageableModel
    {
        public IList<GetCompanyListDto> Items { get; set; }
    }
}
