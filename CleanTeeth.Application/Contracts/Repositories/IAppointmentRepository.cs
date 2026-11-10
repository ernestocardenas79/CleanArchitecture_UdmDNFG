using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Contracts.Repositories;

public interface IAppointmentRepository: IRepository<Appointment>
{
    Task<bool> OverlapExists(Guid dentistId, DateTime start, DateTime end);
    new Task<Appointment?> GetById(Guid id);
    Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO filter);
}
