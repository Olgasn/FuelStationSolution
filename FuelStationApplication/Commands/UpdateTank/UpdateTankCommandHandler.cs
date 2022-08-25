using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Commands.UpdateTank
{
    public class UpdateTankCommandHandler : IRequestHandler<UpdateTankCommand>
    {

        private readonly IFuelStationDbContext _dbContext;

        public UpdateTankCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTankCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tanks.FirstOrDefaultAsync(tank =>
                    tank.Id == request.Id, cancellationToken);

            if (entity == null || request.TankType ==null)
            {
                throw new NotFoundException(nameof(Tank), request.Id);
            }
            entity.TankType = request.TankType;
            entity.TankMaterial = request.TankMaterial;
            entity.TankWeight = request.TankWeight;
            entity.TankVolume = request.TankVolume;
            entity.TankPicture = request.TankPicture;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
