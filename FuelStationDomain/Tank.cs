namespace FuelStation.Domain
{
    public class Tank
    {
        //ID емкости
        public Guid Id { get; set; }
        //Тип емкости
        public string TankType { get; set; } = null!;
        //Вес емкости
        public float TankWeight { get; set; }
        //Объем емкости
        public float TankVolume { get; set; }
        //Материал емкости
        public string? TankMaterial { get; set; }
        //Ссылка на изображение емкости
        public string? TankPicture { get; set; }


    }
}
