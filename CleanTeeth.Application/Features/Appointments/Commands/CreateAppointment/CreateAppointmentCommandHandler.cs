using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Notifications;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly INotifications notifications;

    public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, INotifications notifications)
    {
        this.appointmentRepository = appointmentRepository;
        this.unitOfWork = unitOfWork;
        this.notifications = notifications;
    }
    public async Task<Guid> Handle(CreateAppointmentCommand request)
    {
        var existOverlapt = await appointmentRepository.OverlapExists(request.DentistId, request.StartDate, request.EndDate);

        if (existOverlapt)
        {
            throw new CustomValidationException("The dentist has an overlapping appointment.");
        }

        var timeInterval = new TimeInterval(request.StartDate, request.EndDate);
        var appointment = new Appointment(request.PatientId, request.DentistId, request.DentalOfficeId, timeInterval);

        Guid? id = null;
        try
        {
            var result =await appointmentRepository.Add(appointment);
            await unitOfWork.Commit();
            id= result.Id;
        }
        catch (Exception ex)
        {
            await unitOfWork.Rollback();
            throw;
        }

        var appointmentDB = await appointmentRepository.GetById(id.Value);
        var notificationDTO = appointmentDB!.ToDTO();
        await notifications.SendAppointmentConfirmation(notificationDTO);

        return id.Value;
    }
}
