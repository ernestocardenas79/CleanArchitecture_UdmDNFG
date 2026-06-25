using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public class GetDentalOfficesListQueryHandler : IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>
{
    private readonly IDentalOfficeRepository dentalOfficeRepository;

    public GetDentalOfficesListQueryHandler(IDentalOfficeRepository dentalOfficeRepository)
    {
        this.dentalOfficeRepository = dentalOfficeRepository;
    }
    public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficesListQuery request)
    {
        var dentalOffices = await dentalOfficeRepository.GetAll();
        var dentalOfficesListDTO = dentalOffices.Select(d => d.ToDTO()).ToList();
        return dentalOfficesListDTO;
    }
}
