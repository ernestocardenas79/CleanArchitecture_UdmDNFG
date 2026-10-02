using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("The filed {PropertyName} is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("The filed {PropertyName} is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
    }
}
