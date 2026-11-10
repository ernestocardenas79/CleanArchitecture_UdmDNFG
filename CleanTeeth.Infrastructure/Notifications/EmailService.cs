using CleanTeeth.Application.Notifications;

namespace CleanTeeth.Infrastructure.Notifications;

public class EmailService : INotifications
{
    public Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmationDTO)
    {
        throw new NotImplementedException();
    }
}
