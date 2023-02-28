using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainerStudents.Commands.DeletePersonalTrainerStudent
{
    public class DeletePersonalTrainerStudentCommandValidator:AbstractValidator<DeletePersonalTrainerStudentCommand>
    {
        public DeletePersonalTrainerStudentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
