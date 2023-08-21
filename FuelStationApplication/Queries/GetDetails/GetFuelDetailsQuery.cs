using MediatR;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetFuelDetailsQuery : IRequest<FuelDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
