using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;

public class UpdateDentalOfficeCommand:IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
