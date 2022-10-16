﻿using MediatR;

namespace FuelStation.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommand : IRequest
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



    }
}
