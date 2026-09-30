using FluentValidation;

namespace CleanTeeth.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The property {PropertyName} is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The property {PropertyName} is required")
            .EmailAddress()
            .WithMessage("Invalid email format");
    }
}