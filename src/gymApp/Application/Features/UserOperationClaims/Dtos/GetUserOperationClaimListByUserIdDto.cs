﻿using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Dtos
{
    public class GetUserOperationClaimListByUserIdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int[] OperationClaimIds{ get; set; }
    }
}
