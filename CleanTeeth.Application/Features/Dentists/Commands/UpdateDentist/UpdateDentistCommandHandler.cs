using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Dentists.Commands.UpdateDentist;

public class UpdateDentistCommandHandler : IRequestHandler<UpdateDentistCommand>
{
    private readonly IDentistRepository dentistRepository;
    private readonly IUnitOfWork unitOfWork;

    public UpdateDentistCommandHandler(IDentistRepository dentistRepository, IUnitOfWork unitOfWork)
    {
        this.dentistRepository = dentistRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateDentistCommand request)
    {
        var dentist = await dentistRepository.GetById(request.Id);

        if(dentist is null)
        {
            throw new NotFoundException();
        }

        dentist.UpdateName(request.Name);
        dentist.UpdateEmail(new Email(request.Email));

        await dentistRepository.Update(dentist);
        await unitOfWork.Commit();
    }
}
