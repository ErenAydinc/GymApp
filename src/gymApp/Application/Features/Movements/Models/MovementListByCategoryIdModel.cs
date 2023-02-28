using Application.Features.Movements.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Models
{
    public class MovementListByCategoryIdModel:BasePageableModel
    {
        public IList<GetMovementListByCategoryIdDto> Items { get; set; }
    }
}
