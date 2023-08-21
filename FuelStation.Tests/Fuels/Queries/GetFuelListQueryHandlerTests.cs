using AutoMapper;
using FuelStation.Application.Queries.GetList;
using FuelStation.Persistence;
using FuelStation.Tests.Common;
using Shouldly;

namespace FuelStation.Tests.Fuels.Queries
{
    [Collection("QueryCollection")]
    public class GetFuelListQueryHandlerTests
    {
        private readonly FuelStationDbContext Context;
        private readonly IMapper Mapper;

        public GetFuelListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFuelListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFuelListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetFuelListQuery
                {
                    FuelType = ""
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<FuelListVm>();
            result.Fuels.Count.ShouldBe(FuelStationContextFactory.fuelsNumber);
        }
    }
}
