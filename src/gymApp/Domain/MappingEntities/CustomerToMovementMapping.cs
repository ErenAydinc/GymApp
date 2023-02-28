using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MappingEntities
{
    public class CustomerToMovementMapping:Entity
    {
        public int CustomerId { get; set; }
        public int MovementId { get; set; }

        public CustomerToMovementMapping()
        {

        }

        public CustomerToMovementMapping(int customerId, int movementId)
        {
            CustomerId = customerId;
            MovementId = movementId;
        }
    }
}
