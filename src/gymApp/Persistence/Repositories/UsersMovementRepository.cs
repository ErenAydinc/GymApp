using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UsersMovementRepository : EfRepositoryBase<UsersMovement, BaseDbContext>, IUsersMovementRepository
    {
        public UsersMovementRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
