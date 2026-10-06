using CleanTeeth.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentists;

public class GetDentistsQuery: DentistFilterDTO, IRequest<PaginatedDTO<DentistListDTO>>
{
}
