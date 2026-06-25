using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public class DentalOfficesListDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
