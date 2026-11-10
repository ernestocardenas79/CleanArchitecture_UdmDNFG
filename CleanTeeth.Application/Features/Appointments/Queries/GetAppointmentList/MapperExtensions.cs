using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;

internal static class MapperExtensions
{
    internal static AppointmentsListDTO ToDTO(this Appointment appointment)
    {
        return new AppointmentsListDTO
        {
            Id = appointment.Id,
            StartDate = appointment.TimeInterval.Start,
            EndDate = appointment.TimeInterval.End,
            DentalOffice = appointment.DentalOffice!.Name,
            Dentist = appointment.Dentist!.Name,
            Patient = appointment.Patient!.Name,
            Status = appointment.Status.ToString()
        };
    }
}
