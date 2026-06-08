using FluentValidation;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandValidator: AbstractValidator<CreateDentalOfficeCommand>
{
    public CreateDentalOfficeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("the field {PropertyName} is required.");
    }
}