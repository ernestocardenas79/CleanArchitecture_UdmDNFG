using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Commands.CancelAppointment;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IAppointmentRepository repository;
    public CancelAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository)
    {
        this.unitOfWork = unitOfWork;
        this.repository = repository;
    }
    public async Task Handle(CancelAppointmentCommand request)
    {
        var appointment = await repository.GetById(request.Id);
        if (appointment == null)
        {
            throw new NotFoundException();
        }
        appointment.Cancel();
        try
        {
            await repository.Update(appointment);
            await unitOfWork.Commit();
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}