using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Patients.Commands.DeletePatient;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository patientRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeletePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        this.patientRepository = patientRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task Handle(DeletePatientCommand request)
    {
       var patient = await patientRepository.GetById(request.Id);
        if (patient is null)
        {
            throw new NotFoundException();
        }

        try
        {
            await patientRepository.Delete(patient);
            await unitOfWork.Commit();
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}
