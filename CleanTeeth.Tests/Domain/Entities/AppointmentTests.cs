using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Tests.Domain.Entities;

[TestClass]
public class AppointmentTests
{
    private Guid _patientId = Guid.NewGuid();
    private Guid _dentistId = Guid.NewGuid();
    private Guid _dentalOfficeId = Guid.NewGuid();
    private TimeInterval _timeInterval = new TimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));


    [TestMethod]
    public void Constructor_ValidAppointment_StatusIScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
        Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
        Assert.AreEqual(_patientId, appointment.PatientId);
        Assert.AreEqual(_dentistId, appointment.DentistId);
        Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
        Assert.AreEqual(_timeInterval, appointment.TimeInterval);
        Assert.AreNotEqual(Guid.Empty, appointment.Id);
    }

    [TestMethod]
    public void Constructor_StartTimeInThePast_Throws()
    {
        var pastInterval = new TimeInterval(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1));
        Assert.ThrowsExactly<BussinessRuleException>(() => new Appointment(_patientId, _dentistId, _dentalOfficeId, pastInterval));
    }

    [TestMethod]
    public void Cancel_CancellingAppointment_SetsStatusToCancelled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
        appointment.Cancel();
        Assert.AreEqual(AppointmentStatus.Cancelled, appointment.Status);
    }
    [TestMethod]
    public void Cancel_CancellingAppoinment_ThrowsIfStatusNotScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
        appointment.Cancel();
        Assert.ThrowsExactly<BussinessRuleException>(() => appointment.Cancel());
    }

    [TestMethod]
    public void Complete_CompletingAppointment_SetsStatusToCompleted()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
        appointment.Complete();
        Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
    }

    [TestMethod]
    public void Complete_CompletingAppointment_ThrowsIfStatusNotScheduled()
    {
        var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
        appointment.Cancel();
        Assert.ThrowsExactly<BussinessRuleException>(() => appointment.Complete());
    }
}