using MediatR;

namespace FuelStation.Application.Commands.DeleteOperation
{
    public class DeleteOperationCommand : IRequest
    {
        //Код емкости
        public Guid Id { get; set; }
    }
}
