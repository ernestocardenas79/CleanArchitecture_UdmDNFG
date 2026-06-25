using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Domain.Entities;
using NSubstitute;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

public class GetDentalOfficesListQueryHandlerTests
{
    [TestClass]
    public class GetDentalOfficesListQueryHadlerTests {

#pragma warning disable CS8618
        private IDentalOfficeRepository repository;
        private GetDentalOfficesListQueryHandler handler;
#pragma warning restore CS8618


        [TestInitialize]
        public void Setup()
        {
            repository= Substitute.For<IDentalOfficeRepository>();
            handler = new GetDentalOfficesListQueryHandler(repository);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreDentalOffices_ReturnsListOfThem()
        {
            var dentalOffices = new List<DentalOffice>
            {
                new DentalOffice("Dental Office 1"),
                new DentalOffice("Dental Office 2")
            };

            repository.GetAll().Returns(dentalOffices);

            var expected = dentalOffices.Select(d => new DentalOfficesListDTO { Id = d.Id, Name = d.Name }).ToList();

            var result = await handler.Handle(new GetDentalOfficesListQuery());

            Assert.HasCount(expected.Count, result);

            for(int i = 0; i < expected.Count; i++) {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
            }
        }
        [TestMethod]
        public async Task Handle_WhenThereAreNoDentalOffices_ReturnsEmptyList()
        {
            repository.GetAll().Returns(new List<DentalOffice>());
            var result = await handler.Handle(new GetDentalOfficesListQuery());
            Assert.IsNotNull(result);
            Assert.HasCount(0, result);
        }
    }
}
