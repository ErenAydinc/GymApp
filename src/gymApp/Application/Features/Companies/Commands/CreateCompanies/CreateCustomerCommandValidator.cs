using Application.Features.Companies.Commands.CreateCompany;
using FluentValidation;

namespace Application.Features.Companies.Commands.CreateCustomer
{
    public class CreateCompanyCommandValidator:AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
