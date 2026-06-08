using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTheet.Domain.Entities;
using FluentValidation;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository, 
                                              IUnitOfWork unitOfWork)
                     : IRequestHandler<CreateDentalOfficeCommand, Guid>
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command)
    {
        var dentalOffice = new DentalOffice(command.Name);
        try
        {
            var result = await dentalOfficeRepository.Add(dentalOffice);
            await unitOfWork.Commit();
            return result.Id;
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}