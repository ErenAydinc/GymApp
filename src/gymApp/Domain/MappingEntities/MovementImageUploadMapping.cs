using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MappingEntities
{
    public class MovementImageUploadMapping:Entity
    {
        public int MovementId { get; set; }
        public int ImageUploadId { get; set; }

        public MovementImageUploadMapping()
        {

        }

        public MovementImageUploadMapping(int movementId, int imageUploadId)
        {
            MovementId = movementId;
            ImageUploadId = imageUploadId;
        }
    }
}
