using FuelStation.Application.Common.Exceptions;
using FuelStation.Application.Interfaces;
using FuelStation.Domain;
using MediatR;

namespace FuelStation.Application.Commands.DeleteOperation
{
    public class DeleteOperationCommandHandler : IRequestHandler<DeleteOperationCommand>
    {
        private readonly IFuelStationDbContext _dbContext;

        public DeleteOperationCommandHandler(IFuelStationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteOperationCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Operations
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Operation), request.Id);
            }

            _dbContext.Operations.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
