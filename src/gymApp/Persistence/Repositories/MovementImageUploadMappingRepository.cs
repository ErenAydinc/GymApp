using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.MappingEntities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MovementImageUploadMappingRepository : EfRepositoryBase<MovementImageUploadMapping, BaseDbContext>, IMovementImageUploadMappingRepository
    {
        public MovementImageUploadMappingRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
