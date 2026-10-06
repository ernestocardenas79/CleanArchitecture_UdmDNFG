using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Commands.DeleteDentist;

public class DeleteDentistCommandHandler : IRequestHandler<DeleteDentistCommand>
{
    private readonly IDentistRepository dentistRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteDentistCommandHandler(IDentistRepository dentistRepository, IUnitOfWork unitOfWork)
    {
        this.dentistRepository = dentistRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteDentistCommand request)
    {
        var dentist = await dentistRepository.GetById(request.Id);
        if (dentist == null)
        {
            throw new NotFoundException();
        }

        await dentistRepository.Delete(dentist);
        await unitOfWork.Commit();
    }
}