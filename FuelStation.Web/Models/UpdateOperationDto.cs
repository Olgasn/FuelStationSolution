using AutoMapper;
using FuelStation.Application.Commands.UpdateOperation;
using FuelStation.Application.Common.Mappings;

namespace FuelStation.Web.Models
{
    public class UpdateOperationDto : IMapWith<UpdateOperationCommand>
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


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOperationDto, UpdateOperationCommand>()
                .ForMember(operationCommand => operationCommand.Id,
                    opt => opt.MapFrom(operationDto => operationDto.Id))
                .ForMember(operationCommand => operationCommand.TankId,
                    opt => opt.MapFrom(operationDto => operationDto.TankId))
                .ForMember(operationCommand => operationCommand.FuelId,
                    opt => opt.MapFrom(operationDto => operationDto.FuelId))
                .ForMember(operationCommand => operationCommand.Inc_Exp,
                    opt => opt.MapFrom(operationDto => operationDto.Inc_Exp))
                .ForMember(operationCommand => operationCommand.OperationDate,
                    opt => opt.MapFrom(operationDto => operationDto.OperationDate));
        }
    }
}
