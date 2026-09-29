using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientList;

public class GetPatientListQuery: PatientFilterDTO, IRequest<PaginatedDTO<PatientListDTO>>
{

}
