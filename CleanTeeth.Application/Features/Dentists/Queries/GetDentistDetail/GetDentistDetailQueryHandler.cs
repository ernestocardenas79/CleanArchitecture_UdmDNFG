using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;

public class GetDentistDetailQueryHandler : IRequestHandler<GetDentistDetailQuery, DentistDetailDTO>
{
    private readonly IDentistRepository dentistRepository;

    public GetDentistDetailQueryHandler(IDentistRepository dentistRepository)
    {
        this.dentistRepository = dentistRepository;
    }

    public async Task<DentistDetailDTO> Handle(GetDentistDetailQuery request)
    {
        var dentist = await dentistRepository.GetById(request.Id);
        
        if(dentist is null)
        {
            throw new NotFoundException();
        }

        return new DentistDetailDTO
        {
            Id = dentist.Id,
            Name = dentist.Name,
            Email = dentist.Email.Value
        };
    }
}
