using MediatR;

namespace FuelStation.Application.Commands.CreateTank
{
    public class CreateTankCommand:IRequest<Guid>
    {
        //Код емкости
        public Guid Id { get; set; }        
        //Название емкости
        public string TankType { get; set; } = null!;
        public float TankWeight { get; set; }
        //Объем емкости
        public float TankVolume { get; set; }
        //Материал емкости
        public string? TankMaterial { get; set; }
        //Ссылка на изображение емкости
        public string? TankPicture { get; set; }


    }
}
