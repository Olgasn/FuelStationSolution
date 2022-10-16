using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Domain;

namespace FuelStation.Application.Queries.GetList
{
    public class OperationLookupDto : IMapWith<Operation>
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

        //Тип емкости
        public string TankType { get; set; } = null!;
        //Тип топлива
        public string FuelType { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Operation, OperationLookupDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(op => op.Id))
                .ForMember(dto => dto.FuelId,
                    opt => opt.MapFrom(op => op.FuelId))
                .ForMember(dto => dto.TankId,
                    opt => opt.MapFrom(op => op.TankId))
                .ForMember(dto => dto.Inc_Exp,
                    opt => opt.MapFrom(op => op.Inc_Exp))
                .ForMember(dto => dto.TankType,
                    opt => opt.MapFrom(op => op.Tank.TankType))
                .ForMember(dto => dto.FuelType,
                    opt => opt.MapFrom(op => op.Fuel.FuelType));
        }
    }
}
