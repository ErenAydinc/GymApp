using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainerStudents.Commands.CreatePersonalTrainerStudent
{
    public class CreatePersonalTrainerStudentCommandValidator : AbstractValidator<CreatePersonalTrainerStudentCommand>
    {
        public CreatePersonalTrainerStudentCommandValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.PersonalTrainerId).NotEmpty();
        }
    }
}
