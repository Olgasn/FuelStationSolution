using FuelStation.Application.Commands.DeleteTank;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Tests.Common;

namespace FuelStation.Tests.Tanks.Commands
{
    public class DeleteTankCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteTankCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteTankCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteTankCommand
            {
                Id = FuelStationContextFactory.IdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Tanks.SingleOrDefault(tank =>
                tank.Id == FuelStationContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteTankCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteTankCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTankCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }


    }
}
