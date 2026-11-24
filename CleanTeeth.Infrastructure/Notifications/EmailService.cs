using CleanTeeth.Application.Notifications;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CleanTeeth.Infrastructure.Notifications;

public class EmailService : INotifications
{
    private readonly IConfiguration configuration;

    public EmailService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmationDTO)
    {
        var subject = "Appointment Confirmation";
        var body = $"Dear {appointmentConfirmationDTO.Patient},\n\n" +
                   $"Your appointment with Dr. {appointmentConfirmationDTO.Dentist} is confirmed for {appointmentConfirmationDTO.Date:MMMM dd, yyyy} at {appointmentConfirmationDTO.Date:hh:mm tt}.\n\n" +
                   $"Thank you for choosing our dental clinic!\n\n" +
                   $"Best regards,\n" +
                   $"Clean Teeth Dental Clinic";

        await SendEmail(appointmentConfirmationDTO.Patient_Email, subject, body);
    }

    public async Task SendAppointmentReminder(AppointmentReminderDTO appointmentReminderDTO)
    {
        var subject = "Appointment Reminder - Clean Teeth Dental Clinic";
        var body = $"Dear {appointmentReminderDTO.Patient},\n\n" +
                   $"This is a friendly reminder for your upcoming appointment with Dr. {appointmentReminderDTO.Dentist} on {appointmentReminderDTO.Date:MMMM dd, yyyy} at {appointmentReminderDTO.Date:hh:mm tt}.\n\n" +
                   $"Thank you for choosing our dental clinic!\n\n" +
                   $"Best regards,\n" +
                   $"Clean Teeth Dental Clinic";

        await SendEmail(appointmentReminderDTO.Patient_Email, subject, body);
    }

    private async Task SendEmail(string to, string subject, string body)
    {
        var from = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:From");
        var password = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:Password");
        var host = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:Host");
        var port = configuration.GetValue<int>("EMAIL_CONFIGURATIONS:Port");

        var smtpClient = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(from, password),
            EnableSsl = true,
            UseDefaultCredentials = false
        };

        var message = new MailMessage(from!, to, subject, body);
        await smtpClient.SendMailAsync(message);
    }
}
