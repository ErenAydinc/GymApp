using Application.Features.BodyInformations.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Models
{
    public class BodyInformationListModel:BasePageableModel
    {
        public IList<GetBodyInformationListDto> Items { get; set; }
    }
}
