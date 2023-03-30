using Application.Features.Commons.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons.Models
{
    public class CommonUserMovementListModel:BasePageableModel
    {
        public IList<CommonUserMovementListDto> Items { get; set; }
    }
}
