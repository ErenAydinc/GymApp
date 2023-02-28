using Core.Persistence.Repositories;
using Domain.MappingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface ICustomerToMovementMappingRepository : IAsyncRepository<CustomerToMovementMapping>, IRepository<CustomerToMovementMapping>
    {
    }
}
