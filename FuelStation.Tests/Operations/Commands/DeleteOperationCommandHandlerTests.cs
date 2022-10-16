using FuelStation.Application.Commands.DeleteOperation;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Tests.Common;

namespace FuelStation.Tests.Operations.Commands
{
    public class DeleteOperationCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteOperationCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteOperationCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteOperationCommand
            {
                Id = FuelStationContextFactory.IdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Operations.SingleOrDefault(op =>
                op.Id == FuelStationContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteOperationCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteOperationCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteOperationCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }


    }
}
