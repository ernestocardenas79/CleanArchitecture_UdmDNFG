using CleanTeeth.Domain.Enums;

namespace CleanTeeth.Application.Contracts.Repositories.Models;

public class AppointmentsFilterDTO
{
    public Guid? PatientID { get; set; }
    public Guid? DentistId { get; set; }
    public Guid? DentalOfficeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public AppointmentStatus? AppointmentStatus { get; set; }
}
