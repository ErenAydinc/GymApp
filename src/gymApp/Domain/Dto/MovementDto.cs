﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class MovementDto
    {
        public int MovementId { get; set; }
        public string Name { get; set; }
        public int MovementImageId { get; set; }
        public int ImagePath { get; set; }
    }
}
