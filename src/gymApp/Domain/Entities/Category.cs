﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }

        public Category()
        {

        }

        public Category(string name, int companyId)
        {
            Name = name;
            CompanyId = companyId;
        }
    }
}
