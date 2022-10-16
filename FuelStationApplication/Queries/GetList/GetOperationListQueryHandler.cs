using AutoMapper;
using AutoMapper.QueryableExtensions;
using FuelStation.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Queries.GetList
{
    public class GetOperationListQueryHandler
        : IRequestHandler<GetOperationListQuery, OperationListVm>
    {
        private readonly IFuelStationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOperationListQueryHandler(IFuelStationDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OperationListVm> Handle(GetOperationListQuery request,
            CancellationToken cancellationToken)
        {
            var operationsQuery = await _dbContext.Operations
                .Include(t => t.Tank)
                .Where(op => op.Tank.TankType.Contains(request.TankType ?? ""))
                .Include(f => f.Fuel)
                .Where(op => op.Fuel.FuelType.Contains(request.FuelType ?? ""))
                .ProjectTo<OperationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OperationListVm { Operations = operationsQuery };
        }
    }
}
