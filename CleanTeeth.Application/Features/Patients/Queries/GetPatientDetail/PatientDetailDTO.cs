using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;

public class PatientDetailDTO
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
