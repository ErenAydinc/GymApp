using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel: BasePageableModel
    {
        public IList<OperationClaim> Items { get; set; }
    }
}
