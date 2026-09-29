using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientList;

public class GetPatientListQueryHandler:IRequestHandler<GetPatientListQuery, PaginatedDTO<PatientListDTO>>
{
    private readonly IPatientRepository patientRepository;

    public GetPatientListQueryHandler(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }

    public async Task<PaginatedDTO<PatientListDTO>> Handle(GetPatientListQuery request)
    {
        var patients = await patientRepository.GetFiltered(request);
        var patientsDTO = patients.Select(patient=> patient.ToDTO()).ToList();
        var totalAmountOfRecords = await patientRepository.GetTotalAmountOfRecords();

        return new() { Elements = patientsDTO, TotalAmountOfRecords = totalAmountOfRecords };
    }
}
