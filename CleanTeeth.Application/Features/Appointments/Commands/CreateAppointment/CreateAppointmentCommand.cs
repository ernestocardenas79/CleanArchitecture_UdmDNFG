using CleanTeeth.Application.Utilities;
using FluentValidation;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommand:IRequest<Guid>
{
    public Guid PatientId { get; set; }
    public Guid DentistId { get; set; }
    public Guid DentalOfficeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}


public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(x => x.StartDate).GreaterThan(x => x.EndDate).WithMessage("Start date must be before end date.");
    }
}