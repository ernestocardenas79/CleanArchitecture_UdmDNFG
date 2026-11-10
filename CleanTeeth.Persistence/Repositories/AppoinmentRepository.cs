using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;
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

    new public async Task<Appointment?> GetById(Guid id)
    {
        return await context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Dentist)
            .Include(a => a.DentalOffice)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO filter)
    {
        var query = context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Dentist)
            .Include(a => a.DentalOffice).AsQueryable();

        if(filter.DentalOfficeId is not null)
        {
            query = query.Where(a => a.DentalOfficeId == filter.DentalOfficeId);
        }

        if(filter.DentistId is not null)
        {
            query = query.Where(a => a.DentistId == filter.DentistId);
        }

        if(filter.PatientID is not null)
        {
            query = query.Where(a => a.PatientId == filter.PatientID);
        }

        return await query
            .Where(a => a.TimeInterval.Start >= filter.StartDate && a.TimeInterval.End <= filter.EndDate)
            .OrderBy(a => a.TimeInterval.Start)
            .ToListAsync();
    }
}
