using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CustomerRepository : EfRepositoryBase<Customer, BaseDbContext>, ICustomerRepository
    {
        public CustomerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
