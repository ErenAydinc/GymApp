using Application.Features.Users.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Models
{
    public class UserByCustomerListModel:BasePageableModel
    {
        public IList<GetUserByCustomerIdDto> Items { get; set; }
    }
}
