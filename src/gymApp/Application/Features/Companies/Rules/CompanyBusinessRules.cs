using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Companies.Rules
{
    public class CompanyBusinessRules
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyBusinessRules(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task CompanyAlreadyExists(int id)
        {
            Company? company = await _companyRepository.GetAsync(x => x.Id == id);

            if (company != null) throw new BusinessException("Company already exists");
        }

        public async Task CompanyNotAlreadyExists(int id)
        {
            Company? company = await _companyRepository.GetAsync(x => x.Id == id);

            if (company == null) throw new BusinessException("Company not already exists");
        }
    }
}
