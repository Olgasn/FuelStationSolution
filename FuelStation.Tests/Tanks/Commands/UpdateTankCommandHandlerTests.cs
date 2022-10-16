using FuelStation.Application.Commands.UpdateTank;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Tests.Common;
using Microsoft.EntityFrameworkCore;


namespace FuelStation.Tests.Tanks.Commands
{
    public class UpdateTankCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateTankCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateTankCommandHandler(Context);
            var updatedTitle = "new tank title";

            // Act
            await handler.Handle(new UpdateTankCommand
            {
                Id = FuelStationContextFactory.IdForUpdate,
                TankType = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Tanks.SingleOrDefaultAsync(tank =>
                tank.Id == FuelStationContextFactory.IdForUpdate &&
                tank.TankType == updatedTitle));
        }

        [Fact]
        public async Task UpdateTankCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateTankCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTankCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }


    }
}
