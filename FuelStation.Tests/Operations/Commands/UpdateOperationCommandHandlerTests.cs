using Microsoft.EntityFrameworkCore;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Commands.UpdateOperation;
using FuelStation.Tests.Common;


namespace FuelStation.Tests.Operations.Commands
{
    public class UpdateOperationCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateOperationCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateOperationCommandHandler(Context);
            float updatedInc_Exp = -23.4f;
            var updatedOperationDate= new DateTime(2015, 7, 20);

            // Act
            await handler.Handle(new UpdateOperationCommand
            {
                Id = FuelStationContextFactory.IdForUpdate,
                Inc_Exp = updatedInc_Exp,
                OperationDate=updatedOperationDate
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Operations.SingleOrDefaultAsync(op =>
                op.Id == FuelStationContextFactory.IdForUpdate &&
                op.Inc_Exp == updatedInc_Exp && op.OperationDate == updatedOperationDate));
        }

        [Fact]
        public async Task UpdateOperationCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateOperationCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateOperationCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateOperationCommandHandler_FailOnWrongForeignKeys()
        {
            // Arrange
            var handler = new UpdateOperationCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateOperationCommand
                    {
                        FuelId = FuelStationContextFactory.IdForUpdate,
                        TankId = FuelStationContextFactory.IdForUpdate,

                    },
                    CancellationToken.None);
            });

        }
    }
}
