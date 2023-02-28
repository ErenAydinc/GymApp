using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public interface IHelperService
    {
        Task<int> CurrentUser();
        Task<int> CurrentCustomer();
        Task<int> CurrentCompany();
        Task<string> FullName(int userId);
    }
}
