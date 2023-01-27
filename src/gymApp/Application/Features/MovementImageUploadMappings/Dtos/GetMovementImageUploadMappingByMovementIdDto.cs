using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MovementImageUploadMappings.Dtos
{
    public class GetMovementImageUploadMappingByMovementIdDto
    {
        public int Id { get; set; }
        public int MovementId { get; set; }
        public int ImageUploadId { get; set; }
    }
}
