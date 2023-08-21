using MediatR;

namespace FuelStation.Application.Commands.CreateFuel
{
    public class CreateFuelCommand : IRequest<Guid>
    {
        //Id Топлива
        public Guid Id { get; set; }
        //Название вида топлива
        public string FuelType { get; set; } = null!;
        //Плотность вида топлива
        public float FuelDensity { get; set; }


    }
}
