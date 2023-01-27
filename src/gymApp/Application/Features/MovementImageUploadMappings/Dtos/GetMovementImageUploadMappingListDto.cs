using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MovementImageUploadMappings.Dtos
{
    public class GetMovementImageUploadMappingListDto
    {
        public int Id { get; set; }
        public int MovementId { get; set; }
        public string MovementName { get; set; }
        public int ImageUploadId { get; set; }
    }
}
