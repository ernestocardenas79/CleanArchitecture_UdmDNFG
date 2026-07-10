using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class DeleteDentalOfficeCommandHandlerTests
{
#pragma warning disable CS8618  
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private DeleteDentalOfficeCommandHandler handler;
#pragma warning restore CS8618
    
    [TestInitialize]
    public void SetUp()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new DeleteDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExist_DeleteAndCommitAreCalled()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var command = new DeleteDentalOfficeCommand{ Id = dentalOffice.Id };
        
        repository.GetById(command.Id).Returns(dentalOffice);
        await handler.Handle(command);
        
        await repository.Received(1).Delete(dentalOffice);
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeDoNotExist_Throws()
    {
        var command = new DeleteDentalOfficeCommand { Id = Guid.NewGuid() };
        repository.GetById(command.Id).ReturnsNull();
        
        await Assert.ThrowsExactlyAsync<NotFoundException>(()=> handler.Handle(command));
    }
    
    [TestMethod]
    public async Task Handle_WhenAnExceptionOccursWhileUpdating_RollbackIsCalled()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var command = new DeleteDentalOfficeCommand { Id = Guid.NewGuid() };
        
        repository.GetById(command.Id).Returns(dentalOffice);
        repository.Delete(dentalOffice).Throws(new InvalidOperationException("Exception"));
        
        await Assert.ThrowsExactlyAsync<InvalidCastException>(()=>handler.Handle(command));
        await unitOfWork.Received(1).Rollback();
    }
}