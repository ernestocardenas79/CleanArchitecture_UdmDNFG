using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;
using NSubstitute;

namespace CleanTeeth.Tests.Application.Features.Patients;

[TestClass]
public class GetPatientsListQueryHandlerTests
{
    private IPatientRepository repository;
    private GetPatientListQueryHandler handler;

    [TestInitialize]
    public void setup()
    {
        repository = Substitute.For<IPatientRepository>();
        handler = new GetPatientListQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_ValidateQuery_RetrurnsPatientsPaginated()
    {
        var patient1 = new Patient (  "John Doe", new("john.doe@example.com" ));
        var patient2 = new Patient (  "Jane Smith", new("jane.smith@example.com" ));
        
        IEnumerable<Patient> patients = new List<Patient> { patient1, patient2 };

        repository.GetFiltered(Arg.Any<PatientFilterDTO>()).Returns(Task.FromResult(patients));

        var query= new GetPatientListQuery { Page= 1, RecordPerPage = 10 };

        var result = await handler.Handle(query);


        Assert.AreEqual(10, result.TotalAmountOfRecords);
        Assert.AreEqual(2, result?.Elements.Count);
    }

    [TestMethod]
    public async Task Handle_WhenThereAreNoPatients_ReturnEmptyListAndZero()
    {
        IEnumerable<Patient> patients = new List<Patient> ();

        repository.GetFiltered(Arg.Any<PatientFilterDTO>()).Returns(Task.FromResult(patients));

        var query = new GetPatientListQuery { Page = 1, RecordPerPage = 10 };
        var result = await handler.Handle(query);

        Assert.AreEqual(0, result.TotalAmountOfRecords);
        Assert.AreEqual(0, result?.Elements.Count);
        Assert.IsNotNull(result?.Elements);
    }
}