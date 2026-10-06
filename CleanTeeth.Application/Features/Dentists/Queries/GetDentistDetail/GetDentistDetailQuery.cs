using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;

public class GetDentistDetailQuery : IRequest<DentistDetailDTO>
{
    public Guid Id { get; set; }
}
