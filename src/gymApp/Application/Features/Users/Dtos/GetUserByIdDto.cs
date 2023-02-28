using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class GetUserByIdDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int Type { get; set; }
        public int TimeZone { get; set; }
        public DateTime MemberStartDate { get; set; }
        public DateTime MemberEndDate { get; set; }
    }
}
