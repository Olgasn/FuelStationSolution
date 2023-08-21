using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;

namespace FuelStation.Application.Commands.CreateFuel
{
    public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, Guid>
    {
        private readonly IFuelStationDbContext _dbContext;

        public CreateFuelCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateFuelCommand request,
            CancellationToken cancellationToken)
        {
            var Fuel = new Fuel
            {
                Id = Guid.NewGuid(),
                FuelType = request.FuelType,
                FuelDensity = request.FuelDensity

            };

            await _dbContext.Fuels.AddAsync(Fuel, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Fuel.Id;
        }
    }
}
