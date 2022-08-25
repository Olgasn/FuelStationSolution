using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;

namespace FuelStation.Application.Commands.DeleteTank
{
    public class DeleteTankCommandHandler : IRequestHandler<DeleteTankCommand>
    {
        private readonly IFuelStationDbContext _dbContext;

        public DeleteTankCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTankCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tanks
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tank), request.Id);
            }

            _dbContext.Tanks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
