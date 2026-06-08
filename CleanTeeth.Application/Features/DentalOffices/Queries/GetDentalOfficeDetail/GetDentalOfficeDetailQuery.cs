using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQuery: IRequest<DentalOfficeDetailDTO>
{
    public required Guid Id { get; set; }
}