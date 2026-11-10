using CleanTeeth.Application.Notifications;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;

internal static class MapperExtensions
{
    public static AppointmentConfirmationDTO ToDTO(this Appointment appointment)
    {
        return new AppointmentConfirmationDTO
        {
            Id = appointment.Id,
            Patient = appointment.Patient!.Name,
            Patient_Email = appointment.Patient!.Email.Value,
            Dentist = appointment.Dentist!.Name,
            DentalOffice = appointment.DentalOffice!.Name,
            Date = appointment.TimeInterval.Start
        };
    }
}
