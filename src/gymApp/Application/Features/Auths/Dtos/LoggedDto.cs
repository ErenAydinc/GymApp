using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Dtos
{
    public class LoggedDto:RefreshedTokenDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims{ get; set; }
    }
}
