using MediatR;

namespace FuelStation.Application.Commands.DeleteTank
{
    public class DeleteTankCommand : IRequest
    {
        //Код емкости
        public Guid Id { get; set; }
    }
}
