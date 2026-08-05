using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CleanTeeth.Tests.Application.Features.Patients;

[TestClass]
public class CreatePatientCommandHandlerTests
{
    private IPatientRepository repository;
    private IUnitOfWork unitOfWork;
    private CreatePatientCommandHandler handler;

    [TestInitialize]
    public void SetUp()
    {
        repository = Substitute.For<IPatientRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new CreatePatientCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async  Task Handle_ValidCommand_ReturnsPatientId()
    {
        var command = new CreatePatientCommand {
            Name = "John Doe",
            Email = "john.doe@example.com"
        };
        var patient = new Patient(command.Name, new Email( command.Email));

        repository.Add(Arg.Any<Patient>()).Returns(patient);

        var result = await handler.Handle(command);

        Assert.AreEqual(patient.Id, result);
        await repository.Received(1).Add(Arg.Any<Patient>());
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenTheresAnError_WeRollback()
    {
        var command = new CreatePatientCommand {
            Name = "John Doe",
            Email = "johndoe@example.com"
        };

        repository.Add(Arg.Any<Patient>()).Throws<Exception>();

        await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command));

        await unitOfWork.Received(1).Rollback();
    }

}
