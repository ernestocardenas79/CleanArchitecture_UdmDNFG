using CleanTheet.Domain.Enums;
using CleanTheet.Domain.Exceptions;
using CleanTheet.Domain.ValueObjects;

namespace CleanTheet.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DentistId { get; private set; }
    public Guid DentalOfficeId { get; private set; }
    public AppoimentStatus Status { get; private set; }
    public TimeInterval TimeInterval { get; private set; }
    public DateTime EndTime { get; private set; }
    public Patient? Patient { get; private set; }
    public Dentist? Dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }

    public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId, TimeInterval timeInterval)
    {
        if (timeInterval.Start < DateTime.Now)
        {
            throw new BussinessRuleException("The start time cannot be in the past");
        }

        PatientId = patientId;
        DentistId = dentistId;
        DentalOfficeId = dentalOfficeId;
        TimeInterval = timeInterval;
        Status = AppoimentStatus.Scheduled;
        Id = Guid.CreateVersion7();
    }

    public void Cancel()
    {
        if (Status != AppoimentStatus.Scheduled)
        {
            throw new BussinessRuleException("Only scheduled appointments can be cancelled");
        }
        Status = AppoimentStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != AppoimentStatus.Scheduled)
        {
            throw new BussinessRuleException("Only scheduled appointments can be completed");
        }
        Status = AppoimentStatus.Completed;
    }
}
