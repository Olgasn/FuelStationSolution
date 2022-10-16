using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;

namespace FuelStation.Application.Commands.CreateOperation
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Guid>
    {
        private readonly IFuelStationDbContext _dbContext;

        public CreateOperationCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateOperationCommand request,
            CancellationToken cancellationToken)
        {
            var operation = new Operation
            {
                Id = Guid.NewGuid(),
                TankId = request.TankId,
                FuelId = request.FuelId,
                Inc_Exp = request.Inc_Exp,
                OperationDate = request.OperationDate
            };

            await _dbContext.Operations.AddAsync(operation, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return operation.Id;
        }
    }
}
