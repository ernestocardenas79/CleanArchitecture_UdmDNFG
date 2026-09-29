using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientList;

internal static class MapperExtensions
{
    internal static PatientListDTO ToDTO(this Patient patient)
    {
        return new PatientListDTO
        {
            Id = patient.Id,
            Name = patient.Name,
            Email = patient.Email.Value
        };
    }
}
