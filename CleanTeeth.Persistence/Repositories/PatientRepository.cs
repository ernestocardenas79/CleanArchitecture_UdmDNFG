using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    private readonly CleanTeethDbContext context;

    public PatientRepository(CleanTeethDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Patient>> GetFiltered(PatientFilterDTO filter)
    {
        return await context.Patients.OrderBy(p => p.Name)
                                     .Paginate(filter.Page, filter.RecordPerPage)
                                     .ToListAsync();
    }
}