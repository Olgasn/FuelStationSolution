using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;

namespace FuelStation.Application.Commands.CreateTank
{
    public class CreateTankCommandHandler : IRequestHandler<CreateTankCommand, Guid>
    {
        private readonly IFuelStationDbContext _dbContext;

        public CreateTankCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateTankCommand request,
            CancellationToken cancellationToken)
        {
            var tank = new Tank
            {
                Id = Guid.NewGuid(),
                TankType = request.TankType,
                TankMaterial = request.TankMaterial,
                TankVolume = request.TankVolume,
                TankWeight = request.TankWeight,
                TankPicture = request.TankPicture
            };

            await _dbContext.Tanks.AddAsync(tank, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return tank.Id;
        }
    }
}
