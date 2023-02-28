using Application.Features.Auths.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Type { get; set; }
        public int TimeZone { get; set; }
        public DateTime MemberStartDate { get; set; } = DateTime.UtcNow;
        public DateTime MemberEndDate { get; set; }
        //[NotMapped]
        //public int CustomerId { get; set; }
    }
}
