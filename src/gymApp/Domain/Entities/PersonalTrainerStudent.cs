using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonalTrainerStudent:Entity
    {
        public int StudentId { get; set; }
        public int PersonalTrainerId { get; set; }
    }
}
