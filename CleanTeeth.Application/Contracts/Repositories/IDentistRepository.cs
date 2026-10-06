using CleanTeeth.Application.Features.Dentists.Queries.GetDentists;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Contracts.Repositories;

public interface IDentistRepository: IRepository<Dentist>
{
    Task<List<Dentist>> GetFiltered(DentistFilterDTO filter);
}
