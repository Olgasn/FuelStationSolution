using AutoMapper;
using FuelStation.Application.Queries.GetDetails;
using FuelStation.Persistence;
using FuelStation.Tests.Common;
using Shouldly;

namespace FuelStation.Tests.Tanks.Queries
{
    [Collection("QueryCollection")]
    public class GetTankDetailsQueryHandlerTests
    {
        private readonly FuelStationDbContext Context;
        private readonly IMapper Mapper;

        public GetTankDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTankDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTankDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTankDetailsQuery
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TankDetailsVm>();
            result.TankType.ShouldBe("Title2");
            result.TankVolume.ShouldBe(123);
        }
    }
}
