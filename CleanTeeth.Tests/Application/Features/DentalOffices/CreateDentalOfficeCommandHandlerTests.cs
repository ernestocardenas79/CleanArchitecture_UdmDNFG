using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class CreateDentalOfficeCommandHandlerTests
{
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private CreateDentalOfficeCommandHandler handler;

    [TestInitialize]
    public void SetUp()
    {
        repository= Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new CreateDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_ValidCommand_RetrurnsDentalOffice()
    {
        var command = new CreateDentalOfficeCommand(){Name = "Dental Office A"};
        
        var dentalOffice = new DentalOffice("Dental Office A");
        
        repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);

        var result = await handler.Handle(command);

        await repository.Received(1).Add(Arg.Any<DentalOffice>());
        await unitOfWork.Received(1).Commit();
        Assert.AreEqual(dentalOffice.Id, result);
    }
    
    [TestMethod]
    public async Task Handle_WhenTheresAnError_WeRollback()
    {
        var command = new CreateDentalOfficeCommand{Name = "Dental Office A"};
        repository.Add(Arg.Any<DentalOffice>()).Throws<Exception>();
        
        await Assert.ThrowsExactlyAsync<Exception>(async () =>await handler.Handle(command));

        await unitOfWork.Received(1).Rollback();
    }
}