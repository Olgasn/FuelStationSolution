using AutoMapper;
using FuelStation.Application.Queries.GetDetails;
using FuelStation.Domain;
using FuelStation.Persistence;
using FuelStation.Tests.Common;
using Shouldly;

namespace FuelStation.Tests.Operations.Queries
{
    [Collection("QueryCollection")]
    public class GetOperationDetailsQueryHandlerTests
    {
        private readonly FuelStationDbContext Context;
        private readonly IMapper Mapper;

        public GetOperationDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOperationDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetOperationDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetOperationDetailsQuery
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<OperationDetailsVm>();
            result.TankId.ShouldBe(Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"));
            result.FuelId.ShouldBe(Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"));
            result.Id.ShouldBe(Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"));
            result.OperationDate.ShouldBe(DateTime.Today);
            result.Inc_Exp.ShouldBe(1000);


        }
    }
}
