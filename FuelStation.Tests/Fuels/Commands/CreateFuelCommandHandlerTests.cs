using FuelStation.Application.Commands.CreateFuel;
using FuelStation.Tests.Common;
using Microsoft.EntityFrameworkCore;


namespace FuelStation.Tests.Fuels.Commands
{
    public class CreateFuelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFuelCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateFuelCommandHandler(Context);
            var FuelType = "Fuel name";
            var FuelDensity = 234;

            // Act
            var FuelId = await handler.Handle(
                new CreateFuelCommand
                {
                    FuelType = FuelType,
                    FuelDensity = FuelDensity,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Fuels.SingleOrDefaultAsync(t =>
                    t.Id == FuelId && t.FuelType == FuelType &&
                    t.FuelDensity == FuelDensity));
        }
    }
}
