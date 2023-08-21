using MediatR;

namespace FuelStation.Application.Commands.DeleteFuel
{
    public class DeleteFuelCommand : IRequest
    {
        //Код емкости
        public Guid Id { get; set; }
    }
}
