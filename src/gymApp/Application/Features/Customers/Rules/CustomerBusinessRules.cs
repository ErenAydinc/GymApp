using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Customers.Rules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CustomerAlreadyExists(int id)
        {
            Customer? customer = await _customerRepository.GetAsync(x => x.Id == id);

            if (customer != null) throw new BusinessException("Customer already exists");
        }

        public async Task CustomerNotAlreadyExists(int id)
        {
            Customer? customer = await _customerRepository.GetAsync(x => x.Id == id);

            if (customer == null) throw new BusinessException("Customer not already exists");
        }
    }
}
