using MediatR;

namespace FuelStation.Application.Queries.GetDetails
{
    public class GetTankDetailsQuery : IRequest<TankDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
