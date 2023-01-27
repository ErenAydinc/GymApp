using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MappingEntities
{
    public class UserMemberTypeMapping:Entity
    {
        public int UserId { get; set; }
        public int MemberTypeId { get; set; }

        public virtual User User { get; set; }
        public virtual MemberType MemberType { get; set; }

        public UserMemberTypeMapping()
        {

        }

        public UserMemberTypeMapping(int id,int userId, int memberTypeId):base(id)
        {
            UserId = userId;
            MemberTypeId = memberTypeId;
        }
    }
}
