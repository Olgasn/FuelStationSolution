using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommandHandler : IRequestHandler<UpdateOperationCommand>
    {

        private readonly IFuelStationDbContext _dbContext;

        public UpdateOperationCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateOperationCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Operations.FirstOrDefaultAsync(operation =>
                    operation.Id == request.Id, cancellationToken);

            if (entity == null || request.Inc_Exp ==null)
            {
                throw new NotFoundException(nameof(Operation), request.Id);
            }
            entity.FuelId = request.FuelId;
            entity.TankId = request.TankId;
            entity.Inc_Exp = request.Inc_Exp;
            entity.OperationDate = request.OperationDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
