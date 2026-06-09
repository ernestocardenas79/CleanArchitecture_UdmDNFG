using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTheet.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTheet.Tests.Application.Features.DentalOffices;

[TestClass]
public class GetDentalOfficeDetailQueryHandlerTests
{
    private IDentalOfficeRepository repository;
    private GetDentalOfficeDetailQueryHandler handler;

    [TestInitialize]
    public void SetUp()
    {
        repository= Substitute.For<IDentalOfficeRepository>();
        handler = new GetDentalOfficeDetailQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_DentalOfficeExists_ReturnsIt()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var id = dentalOffice.Id;
        
        var query = new GetDentalOfficeDetailQuery{ Id = id };
        
        repository.GetById(id).Returns(dentalOffice);

        var result = await handler.Handle(query);
        
        Assert.IsNotNull(result);
        Assert.AreEqual(id, result.Id);
        Assert.AreEqual("Dental Office A",result.Name);
    }

    [TestMethod]
    public async Task Handle_DentalOfficeDoesNotExists_Throws()
    {
        var id = Guid.NewGuid();
        var query = new GetDentalOfficeDetailQuery{ Id = id };
        
        repository.GetById(id).ReturnsNull();
        
        await Assert.ThrowsExactlyAsync<NotFoundException>(async () => await handler.Handle(query));
    }
}