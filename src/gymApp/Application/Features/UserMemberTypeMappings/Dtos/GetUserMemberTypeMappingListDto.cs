using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserMemberTypeMappings.Dtos
{
    public class GetUserMemberTypeMappingListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MemberTypeId { get; set; }
        public string MemberTypeName { get; set; }
    }
}
