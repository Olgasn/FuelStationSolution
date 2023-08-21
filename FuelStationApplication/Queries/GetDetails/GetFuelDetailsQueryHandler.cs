using AutoMapper;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetFuelDetailsQueryHandler
        : IRequestHandler<GetFuelDetailsQuery, FuelDetailsVm>
    {
        private readonly IFuelStationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFuelDetailsQueryHandler(IFuelStationDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FuelDetailsVm> Handle(GetFuelDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Fuels
                .FirstOrDefaultAsync(Fuel =>
                Fuel.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Fuel), request.Id);
            }

            return _mapper.Map<FuelDetailsVm>(entity);
        }
    }
}
