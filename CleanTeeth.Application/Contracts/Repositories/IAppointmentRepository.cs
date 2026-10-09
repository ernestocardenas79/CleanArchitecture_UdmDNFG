using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Contracts.Repositories;

public interface IAppointmentRepository: IRepository<Appointment>
{
    Task<bool> OverlapExists(Guid dentistId, DateTime start, DateTime end);
}
