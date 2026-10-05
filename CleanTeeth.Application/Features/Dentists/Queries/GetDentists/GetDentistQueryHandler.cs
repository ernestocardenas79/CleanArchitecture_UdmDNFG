using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentists;

public class GetDentistQueryHandler : IRequestHandler<GetDentistsQuery, List<DentistListDTO>>
{
    private readonly IDentistRepository dentistRepository;

    public GetDentistQueryHandler(IDentistRepository dentistRepository)
    {
        this.dentistRepository = dentistRepository;
    }

    public async Task<List<DentistListDTO>> Handle(GetDentistsQuery request)
    {
        var dentists = await dentistRepository.GetAll();
        return dentists.Select(d => d.ToDTO()).ToList();
    }
}
