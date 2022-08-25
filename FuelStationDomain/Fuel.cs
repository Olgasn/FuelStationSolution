namespace FuelStation.Domain
{
    public class Fuel
    {
        //Id Топлива
        public Guid Id { get; set; }
        //Название вида топлива
        public string FuelType { get; set; } = null!;
        //Плотность вида топлива
        public float FuelDensity { get; set; }


    }
}
