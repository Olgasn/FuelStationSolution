using AutoMapper;
using FuelStation.Application.Queries.GetDetails;
using FuelStation.Persistence;
using FuelStation.Tests.Common;
using Shouldly;

namespace FuelStation.Tests.Fuels.Queries
{
    [Collection("QueryCollection")]
    public class GetFuelDetailsQueryHandlerTests
    {
        private readonly FuelStationDbContext Context;
        private readonly IMapper Mapper;

        public GetFuelDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFuelDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFuelDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetFuelDetailsQuery
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<FuelDetailsVm>();
            result.FuelType.ShouldBe("Title2");
            result.FuelDensity.ShouldBe(123);
        }
    }
}
