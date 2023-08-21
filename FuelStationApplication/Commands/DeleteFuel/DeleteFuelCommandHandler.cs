using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;

namespace FuelStation.Application.Commands.DeleteFuel
{
    public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand>
    {
        private readonly IFuelStationDbContext _dbContext;

        public DeleteFuelCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteFuelCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Fuels
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Fuel), request.Id);
            }

            _dbContext.Fuels.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;

        }
    }
}
