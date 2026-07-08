using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class UpdateDentalOfficeCommandHandlerTests
{
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private UpdateDentalOfficeCommandHandler handler;

    [TestInitialize]
    public void SetUp()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new UpdateDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
    {
        var dentalOfice = new DentalOffice("Dental Office A");
        var id = dentalOfice.Id;
        var command = new UpdateDentalOfficeCommand
        {
            Id = id,
            Name = "Updated Dental Office A"
        };
        
        repository.GetById(id).Returns(dentalOfice);

        await handler.Handle(command);

        await repository.Received(1).Update(dentalOfice);
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeDoNotExists_Throws() { 
        var command = new UpdateDentalOfficeCommand
        {
            Id = Guid.NewGuid(),
            Name = "Updated Dental Office A"
        };

        repository.GetById(command.Id).ReturnsNull();
        await Assert.ThrowsExactlyAsync<NotFoundException>(async () => await handler.Handle(command));
    }

    [TestMethod]
    public async Task Handle_WhenTheresAnError_WeRollback()
    {
        var dentalOfice = new DentalOffice("Dental Office A");
        var id = dentalOfice.Id;
        var command = new UpdateDentalOfficeCommand
        {
            Id = id,
            Name = "Updated Dental Office A"
        };

        repository.GetById(id).Returns(dentalOfice);
        repository.Update(dentalOfice).Throws(new InvalidOperationException("Exception"));

        await Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => await handler.Handle(command));    
        await unitOfWork.Received(1).Rollback();
    }
}
