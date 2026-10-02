using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;

public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
{
    private readonly IPatientRepository patientRepository;

    public GetPatientDetailQueryHandler(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }

    public async Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
    {
        var patient = await patientRepository.GetById(request.Id);

        if(patient is null)
        {
            throw new NotFoundException();
        }

        return patient.ToDTO();
    }
}
