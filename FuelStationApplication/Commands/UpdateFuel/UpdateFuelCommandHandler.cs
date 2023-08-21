using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Commands.UpdateFuel
{
    public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand>
    {

        private readonly IFuelStationDbContext _dbContext;

        public UpdateFuelCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateFuelCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Fuels.FirstOrDefaultAsync(Fuel =>
                    Fuel.Id == request.Id, cancellationToken);

            if (entity == null || request.FuelType == null)
            {
                throw new NotFoundException(nameof(Fuel), request.Id);
            }
            entity.FuelType = request.FuelType;
            entity.FuelDensity = request.FuelDensity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
