using MediatR;

namespace FuelStation.Application.Queries.GetList
{
    public class GetOperationListQuery : IRequest<OperationListVm>
    {
        public string? TankType { get; set; }
        public string? FuelType { get; set; }



    }
}
