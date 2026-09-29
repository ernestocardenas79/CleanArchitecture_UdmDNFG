using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientList;

public class PatientFilterDTO
{
    public int Page { get; set; } = 1;
    public int RecordPerPage { get; set; } = 10;
}
