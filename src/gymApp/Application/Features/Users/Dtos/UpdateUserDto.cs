using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public int Type { get; set; }
        public int TimeZone { get; set; }
        public DateTime MemberStartDate { get; set; } = DateTime.UtcNow;
        public DateTime MemberEndDate { get; set; }
    }
}
