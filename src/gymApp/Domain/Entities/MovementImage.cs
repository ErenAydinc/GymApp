using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovementImage:Entity
    {
        public int MovementId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? DateTime { get; set; }

        public MovementImage()
        {

        }

        public MovementImage(int movementId, string? imagePath, DateTime? dateTime)
        {
            MovementId = movementId;
            ImagePath = imagePath;
            DateTime = dateTime;
        }
    }
}
