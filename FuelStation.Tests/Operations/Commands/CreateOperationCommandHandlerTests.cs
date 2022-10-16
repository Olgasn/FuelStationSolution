using FuelStation.Application.Commands.CreateOperation;
using FuelStation.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Tests.Operations.Commands
{
    public class CreateOperationCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateOperationCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateOperationCommandHandler(Context);

            var tankId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084");
            var fuelId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084");
            var operationDate = DateTime.Today;
            var inc_Exp = -17766;



            // Act
            var operationId = await handler.Handle(
                new CreateOperationCommand
                {
                    TankId = tankId,
                    FuelId = fuelId,
                    OperationDate = operationDate,
                    Inc_Exp = inc_Exp
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Operations.SingleOrDefaultAsync(t =>
                    t.Id == operationId && t.TankId == tankId &&
                    t.FuelId == fuelId && t.Inc_Exp == inc_Exp && t.OperationDate == operationDate));
        }
    }
}
