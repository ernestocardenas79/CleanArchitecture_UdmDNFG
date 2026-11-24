using CleanTeeth.Application.Notifications;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.SendAppointmentReminder;

internal static class MapperExtensions
{
    internal static AppointmentReminderDTO toDTO(this Appointment appointment)
    {
        return new AppointmentReminderDTO
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
