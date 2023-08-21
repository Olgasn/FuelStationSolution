using MediatR;

namespace FuelStation.Application.Queries.GetList
{
    public class GetFuelListQuery : IRequest<FuelListVm>
    {
        public string? FuelType { get; set; }


    }
}
