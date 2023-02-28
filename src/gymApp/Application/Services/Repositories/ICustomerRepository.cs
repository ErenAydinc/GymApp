using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface ICustomerRepository: IAsyncRepository<Customer>, IRepository<Customer>
    {
    }
}
