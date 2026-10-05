using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentists;

public static class MapperExtensions
{
    public static DentistListDTO ToDTO(this Dentist dentist)
    {
        return new DentistListDTO
        {
            Id = dentist.Id,
            Name = dentist.Name,
            Email = dentist.Email.Value,
        };
    }
}
