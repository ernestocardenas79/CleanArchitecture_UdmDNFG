using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository repository) : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>
{
    public async Task<DentalOfficeDetailDTO> Handle(GetDentalOfficeDetailQuery request)
    {
        var dentalOffice = await repository.GetById(request.Id);

        if (dentalOffice is null)
        {
            throw new NotFoundException();
        }

        return dentalOffice.ToDTO();
    }
}