using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientList;

public class PatientListDTO
{
    public  Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
}
