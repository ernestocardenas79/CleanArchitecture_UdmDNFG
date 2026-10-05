using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Persistence.Repositories;

internal class DentistRepository : Repository<Dentist>, IDentistRepository
{
    public DentistRepository(CleanTeethDbContext context) : base(context)
    {
    }
}
