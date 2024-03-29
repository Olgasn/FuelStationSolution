﻿namespace FuelStation.Domain
{
    public class Operation
    {
        //Id операции
        public Guid Id { get; set; }
        //Id топлива
        public Guid FuelId { get; set; }
        //Id емкости
        public Guid TankId { get; set; }
        //Приход/Расход
        public float? Inc_Exp { get; set; }
        //Дата операции
        public DateTime OperationDate { get; set; }
        public Fuel Fuel { get; set; } = null!;
        //ссылка на емкости
        public Tank Tank { get; set; } = null!;

    }
}
