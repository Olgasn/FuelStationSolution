using FuelStation.Application.Commands.DeleteFuel;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Tests.Common;

namespace FuelStation.Tests.Fuels.Commands
{
    public class DeleteFuelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFuelCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteFuelCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteFuelCommand
            {
                Id = FuelStationContextFactory.IdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Fuels.SingleOrDefault(Fuel =>
                Fuel.Id == FuelStationContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteFuelCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteFuelCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFuelCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }


    }
}
