using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;

public class CretateDentistCommandHandler : IRequestHandler<CreateDentistCommand>
{
    private readonly IDentistRepository dentistRepository;
    private readonly IUnitOfWork unitOfWork;

    public CretateDentistCommandHandler(IDentistRepository dentistRepository, IUnitOfWork unitOfWork)
    {
        this.dentistRepository = dentistRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateDentistCommand request)
    {
       var dentist = new Dentist(request.Name, new Email(request.Email));

        try
        {
            await dentistRepository.Add(dentist);
            await unitOfWork.Commit();
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}
