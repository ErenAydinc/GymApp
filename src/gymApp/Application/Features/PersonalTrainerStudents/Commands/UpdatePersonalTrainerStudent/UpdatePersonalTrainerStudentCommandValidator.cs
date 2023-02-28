using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainerStudents.Commands.UpdatePersonalTrainerStudent
{
    public class UpdatePersonalTrainerStudentCommandValidator:AbstractValidator<UpdatePersonalTrainerStudentCommand>
    {
        public UpdatePersonalTrainerStudentCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.PersonalTrainerId).NotEmpty();
        }
    }
}
