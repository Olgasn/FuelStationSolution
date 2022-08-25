using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FuelStation.Application.Interfaces;

namespace FuelStation.Application.Queries.GetList
{
    public class GetTankListQueryHandler
        : IRequestHandler<GetTankListQuery, TankListVm>
    {
        private readonly IFuelStationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTankListQueryHandler(IFuelStationDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TankListVm> Handle(GetTankListQuery request,
            CancellationToken cancellationToken)
        {
            var tanksQuery = await _dbContext.Tanks
                .Where(tank => tank.TankType.Contains(request.TankType ?? ""))
                .ProjectTo<TankLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TankListVm { Tanks = tanksQuery };
        }
    }
}
