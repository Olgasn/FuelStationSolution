using AutoMapper;
using FuelStation.Application.Queries.GetList;
using FuelStation.Persistence;
using FuelStation.Tests.Common;
using Shouldly;

namespace FuelStation.Tests.Tanks.Queries
{
    [Collection("QueryCollection")]
    public class GetTankListQueryHandlerTests
    {
        private readonly FuelStationDbContext Context;
        private readonly IMapper Mapper;

        public GetTankListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTankListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTankListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTankListQuery
                {
                    TankType = ""
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TankListVm>();
            result.Tanks.Count.ShouldBe(FuelStationContextFactory.tanksNumber);
        }
    }
}
