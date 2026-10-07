using FluentValidation;

namespace CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;

public class CreateDentistCommandValidator : AbstractValidator<CreateDentistCommand>
{
    public CreateDentistCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The property {PropertyName} is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The property {PropertyName} is required")
            .EmailAddress()
            .WithMessage("Invalid email format");
    }
}
