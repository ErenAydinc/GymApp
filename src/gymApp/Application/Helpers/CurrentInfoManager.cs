using Application.Services.Repositories;
using Core.Security.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class HelperManager: IHelperService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public HelperManager(IHttpContextAccessor httpContextAccessor, ICustomerRepository customerRepository, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _customerRepository = customerRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<int> CurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User.GetUserId();
            return user;
        }

        public async Task<int> CurrentCustomer()
        {
            var user = _httpContextAccessor.HttpContext.User.GetUserId();
            var customer = (await _userRepository.GetAsync(x => x.Id == user)).CustomerId;
            var currentCustomer = (await _customerRepository.GetAsync(x => x.Id == customer)).Id;
            return currentCustomer;
        }

        public async Task<int> CurrentCompany()
        {
            var user = _httpContextAccessor.HttpContext.User.GetUserId();
            var company = (await _userRepository.GetAsync(x => x.Id == user)).CompanyId;
            return company;
        }

        public async Task<string> FullName(int userId)
        {
            var userName = (await _userRepository.GetAsync(x => x.Id == userId)).FirstName+" "+ (await _userRepository.GetAsync(x => x.Id == userId)).LastName;
            return userName;
        }
    }
}
