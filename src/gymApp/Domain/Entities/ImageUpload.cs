using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImageUpload : Entity
    {
        public string? ImagePath { get; set; }
        public DateTime? DateTime { get; set; }
        public ImageUpload()
        {

        }
        public ImageUpload(string imagePath, DateTime dateTime)
        {
            ImagePath = imagePath;
            DateTime = dateTime;
        }
    }
}
