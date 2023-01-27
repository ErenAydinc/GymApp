using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.MappingEntities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserMemberTypeMappingRepository : EfRepositoryBase<UserMemberTypeMapping, BaseDbContext>, IUserMemberTypeMappingRepository
    {
        public UserMemberTypeMappingRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
