using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BodyInformation:Entity
    {
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Arm { get; set; }
        public float Shoulder { get; set; }
        public float Leg { get; set; }
        public float Chest { get; set; }
        public int UserId { get; set; }

        public BodyInformation()
        {

        }

        public BodyInformation(float length, float weight, float arm, float shoulder, float leg, float chest,int userId)
        {
            Length = length;
            Weight = weight;
            Arm = arm;
            Shoulder = shoulder;
            Leg = leg;
            Chest = chest;
            UserId = userId;
        }
    }
}
