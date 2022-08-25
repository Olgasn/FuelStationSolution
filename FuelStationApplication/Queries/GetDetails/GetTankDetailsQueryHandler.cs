using AutoMapper;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetTankDetailsQueryHandler
        : IRequestHandler<GetTankDetailsQuery, TankDetailsVm>
    {
        private readonly IFuelStationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTankDetailsQueryHandler(IFuelStationDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TankDetailsVm> Handle(GetTankDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tanks
                .FirstOrDefaultAsync(tank =>
                tank.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tank), request.Id);
            }

            return _mapper.Map<TankDetailsVm>(entity);
        }
    }
}
