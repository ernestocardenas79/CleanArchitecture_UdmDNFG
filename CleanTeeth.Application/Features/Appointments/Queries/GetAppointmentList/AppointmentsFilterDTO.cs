namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;

public class AppointmentsFilterDTO
{
    public Guid? PatientID { get; set; }
    public Guid? DentistId { get; set; }
    public Guid? DentalOfficeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
