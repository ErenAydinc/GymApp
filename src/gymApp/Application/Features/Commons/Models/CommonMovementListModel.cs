using Application.Features.Commons.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Models
{
    public class CommonMovementListModel:BasePageableModel
    {
        public IList<CommonMovementListDto> Items{ get; set; }
    }
}
