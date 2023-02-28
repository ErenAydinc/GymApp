using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IUsersMovementRepository: IAsyncRepository<UsersMovement>, IRepository<UsersMovement>
    {
    }
}
