using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentists;

public class GetDentistQueryHandler : IRequestHandler<GetDentistsQuery, PaginatedDTO<DentistListDTO>>
{
    private readonly IDentistRepository dentistRepository;

    public GetDentistQueryHandler(IDentistRepository dentistRepository)
    {
        this.dentistRepository = dentistRepository;
    }

    public async Task<PaginatedDTO<DentistListDTO>> Handle(GetDentistsQuery request)
    {
        var filteredDentists = await dentistRepository.GetFiltered(request);
        var filteredDentistsDTOs = filteredDentists.Select(d => d.ToDTO()).ToList();

        return new()
        {
            Elements = filteredDentistsDTOs,
            TotalAmountOfRecords = filteredDentistsDTOs.Count
        };
    }
}
