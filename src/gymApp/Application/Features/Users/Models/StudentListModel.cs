using Application.Features.Users.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Models
{
    public class StudentListModel:BasePageableModel
    {
        public IList<GetStudentListDto> Items { get; set; }
    }
}
