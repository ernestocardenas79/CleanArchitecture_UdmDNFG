using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    private readonly CleanTeethDbContext context;

    public AppointmentRepository(CleanTeethDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<bool> OverlapExists(Guid dentistId, DateTime start, DateTime end)
    {
        return await context.Appointments
            .AnyAsync(a => a.DentistId == dentistId && 
                        a.Status == AppointmentStatus.Scheduled && 
                        start < a.TimeInterval.End && 
                        end > a.TimeInterval.Start);
    }
}
