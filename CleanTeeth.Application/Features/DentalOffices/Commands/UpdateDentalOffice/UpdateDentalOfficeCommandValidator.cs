using FluentValidation;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;

public class UpdateDentalOfficeCommandValidator : AbstractValidator<UpdateDentalOfficeCommand>
{
    public UpdateDentalOfficeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
    }
}