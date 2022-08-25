using Microsoft.EntityFrameworkCore;
using FuelStation.Application.Commands.CreateTank;
using FuelStation.Tests.Common;


namespace FuelStation.Tests.Tanks.Commands
{
    public class CreateTankCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateTankCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateTankCommandHandler(Context);
            var tankType = "tank name";
            var tankVolume = 234;

            // Act
            var tankId = await handler.Handle(
                new CreateTankCommand
                {
                    TankType = tankType,
                    TankVolume = tankVolume,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Tanks.SingleOrDefaultAsync(t =>
                    t.Id == tankId && t.TankType == tankType &&
                    t.TankVolume == tankVolume));
        }
    }
}
