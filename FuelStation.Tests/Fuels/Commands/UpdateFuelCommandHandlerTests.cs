using FuelStation.Application.Commands.UpdateFuel;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Tests.Common;
using Microsoft.EntityFrameworkCore;


namespace FuelStation.Tests.Fuels.Commands
{
    public class UpdateFuelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFuelCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateFuelCommandHandler(Context);
            var updatedTitle = "new Fuel title";

            // Act
            await handler.Handle(new UpdateFuelCommand
            {
                Id = FuelStationContextFactory.IdForUpdate,
                FuelType = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Fuels.SingleOrDefaultAsync(Fuel =>
                Fuel.Id == FuelStationContextFactory.IdForUpdate &&
                Fuel.FuelType == updatedTitle));
        }

        [Fact]
        public async Task UpdateFuelCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateFuelCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFuelCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }


    }
}
