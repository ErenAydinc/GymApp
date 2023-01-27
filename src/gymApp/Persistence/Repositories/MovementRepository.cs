using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class MovementRepository : EfRepositoryBase<Movement, BaseDbContext>, IMovementRepository
    {
        public MovementRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
