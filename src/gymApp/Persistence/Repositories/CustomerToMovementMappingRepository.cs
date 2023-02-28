using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.MappingEntities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CustomerToMovementMappingRepository : EfRepositoryBase<CustomerToMovementMapping, BaseDbContext>, ICustomerToMovementMappingRepository
    {
        public CustomerToMovementMappingRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
