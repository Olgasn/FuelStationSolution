using AutoMapper;
using FuelStation.Application.Queries.GetList;
using FuelStation.Persistence;
using FuelStation.Tests.Common;
using Shouldly;

namespace FuelStation.Tests.Operations.Queries
{
    [Collection("QueryCollection")]
    public class GetOperationListQueryHandlerTests
    {
        private readonly FuelStationDbContext Context;
        private readonly IMapper Mapper;

        public GetOperationListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOperationListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetOperationListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetOperationListQuery
                {
                    TankType = "",
                    FuelType = ""
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<OperationListVm>();
            result.Operations.Count.ShouldBe(FuelStationContextFactory.operationsNumber);
        }
    }
}
