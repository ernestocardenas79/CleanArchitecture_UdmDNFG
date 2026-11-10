using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;

internal static class MapperExtensions
{
    internal static AppointmentDetailDTO ToDto(this Appointment appointment)
    {
        return new AppointmentDetailDTO
        {
            Id = appointment.Id,
            Patient = appointment.Patient!.Name,
            Dentist = appointment.Dentist!.Name,
            DentalOffice = appointment.DentalOffice!.Name,
            StartDate = appointment.TimeInterval.Start,
            EndDate = appointment.TimeInterval.End,
            Status = appointment.Status.ToString()
        };
    }
}
