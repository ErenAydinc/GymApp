using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public Customer()
        {

        }

        public Customer(int id ,string name, string email, string phoneNumber, int companyId):base(id)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            CompanyId = companyId;
        }
    }
}
