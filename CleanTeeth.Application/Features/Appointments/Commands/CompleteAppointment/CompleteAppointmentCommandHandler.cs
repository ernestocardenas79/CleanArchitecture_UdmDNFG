using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Commands.CompleteAppointment;

public class CompleteAppointmentCommandHandler : IRequestHandler<CompleteAppointmentCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IAppointmentRepository repository;
    public CompleteAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository)
    {
        this.unitOfWork = unitOfWork;
        this.repository = repository;
    }
    public async Task Handle(CompleteAppointmentCommand request)
    {
        var appointment = await repository.GetById(request.Id);
        if (appointment == null)
        {
            throw new NotFoundException();
        }

        appointment.Complete();

        try
        {
            await repository.Update(appointment);
            await unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            await unitOfWork.Rollback();
            throw new Exception("An error occurred while updating the appointment.", ex);
        }
    }
}