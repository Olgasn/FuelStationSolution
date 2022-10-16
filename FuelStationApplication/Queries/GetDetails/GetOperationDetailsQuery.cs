using MediatR;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetOperationDetailsQuery : IRequest<OperationDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
