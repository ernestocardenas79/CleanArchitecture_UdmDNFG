using CleanTeeth.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Contracts.Repositories;

public interface IPatientRepository : IRepository<Patient>
{
    Task<IEnumerable<Patient>> GetFiltered(PatientFilterDTO filter);
}