using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;

public class GetPatientDetailQuery: IRequest<PatientDetailDTO>
{
    public required Guid Id { get; set; }
}
