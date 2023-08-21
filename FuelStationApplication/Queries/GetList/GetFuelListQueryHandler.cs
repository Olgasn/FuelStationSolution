using AutoMapper;
using AutoMapper.QueryableExtensions;
using FuelStation.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Queries.GetList
{
    public class GetFuelListQueryHandler
        : IRequestHandler<GetFuelListQuery, FuelListVm>
    {
        private readonly IFuelStationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFuelListQueryHandler(IFuelStationDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FuelListVm> Handle(GetFuelListQuery request,
            CancellationToken cancellationToken)
        {
            var FuelsQuery = await _dbContext.Fuels
                .Where(Fuel => Fuel.FuelType.Contains(request.FuelType ?? ""))
                .ProjectTo<FuelLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FuelListVm { Fuels = FuelsQuery };
        }
    }
}
