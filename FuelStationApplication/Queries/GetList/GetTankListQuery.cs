using MediatR;

namespace FuelStation.Application.Queries.GetList
{
    public class GetTankListQuery : IRequest<TankListVm>
    {
        public string? TankType { get; set; }


    }
}
