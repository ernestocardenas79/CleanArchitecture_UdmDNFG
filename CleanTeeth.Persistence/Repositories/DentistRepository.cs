using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentists;
using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

internal class DentistRepository : Repository<Dentist>, IDentistRepository
{
    private readonly CleanTeethDbContext context;

    public DentistRepository(CleanTeethDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<List<Dentist>> GetFiltered(DentistFilterDTO filter)
    {
       var query = context.Dentists.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(d => d.Name.Contains(filter.Name));
        }

        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(d => d.Email.Value.Contains(filter.Email));
        }

        var res= await query
            .Skip((filter.Page - 1) * filter.RecordPerPage)
            .Take(filter.RecordPerPage)
            .ToListAsync();

        return res;
    }
}
