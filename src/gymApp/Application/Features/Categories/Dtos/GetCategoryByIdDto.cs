﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Dtos
{
    public class GetCategoryByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}
