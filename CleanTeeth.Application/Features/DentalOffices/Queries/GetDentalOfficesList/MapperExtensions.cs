using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

internal static class MapperExtensions
{
    public static DentalOfficesListDTO ToDTO(this DentalOffice dentalOffice)
    {
        return new DentalOfficesListDTO
        {
            Id = dentalOffice.Id,
            Name = dentalOffice.Name
        };
    }
}
