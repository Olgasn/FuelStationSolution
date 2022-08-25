using Microsoft.EntityFrameworkCore;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Commands.UpdateTank;
using FuelStation.Tests.Common;


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
            Assert.NotNull(await Context.Tanks.SingleOrDefaultAsync(note =>
                note.Id == FuelStationContextFactory.IdForUpdate &&
                note.TankType == updatedTitle));
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

        [Fact]
        public async Task UpdateTankCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateTankCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateTankCommand
                    {
                        Id = FuelStationContextFactory.IdForUpdate,
                    },
                    CancellationToken.None);
            });
        }
    }
}
