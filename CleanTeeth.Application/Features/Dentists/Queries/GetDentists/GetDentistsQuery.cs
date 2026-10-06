using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentists;

public class GetDentistsQuery: IRequest<PaginatedDTO<DentistListDTO>>
{
    public DentistFilterDTO Filter { get; set; } = new ();
}
