using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.UserForRegisterDto.Email).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.Password).NotEmpty();
            RuleFor(u => u.UserForRegisterDto.Type).NotEmpty();
        }
    }
}
