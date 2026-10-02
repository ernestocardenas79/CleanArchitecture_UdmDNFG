using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
{
    private readonly IPatientRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public UpdatePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdatePatientCommand request)
    {
        var patient = await repository.GetById(request.Id);

        if (patient is null)
        {
            throw new NotFoundException();
        }

        patient.UpdateName(request.Name);
        patient.UpdateEmail(new Email(request.Email));

        try
        {
            await repository.Update(patient);
            await unitOfWork.Commit();

        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}
