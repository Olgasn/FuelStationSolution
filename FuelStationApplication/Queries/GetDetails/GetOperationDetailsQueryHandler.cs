using AutoMapper;
using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetOperationDetailsQueryHandler
        : IRequestHandler<GetOperationDetailsQuery, OperationDetailsVm>
    {
        private readonly IFuelStationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOperationDetailsQueryHandler(IFuelStationDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OperationDetailsVm> Handle(GetOperationDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Operations
                .Include(t => t.Tank)
                .Include(f => f.Fuel)
                .FirstOrDefaultAsync(op =>
                op.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Operation), request.Id);
            }

            return _mapper.Map<OperationDetailsVm>(entity);
        }
    }
}
