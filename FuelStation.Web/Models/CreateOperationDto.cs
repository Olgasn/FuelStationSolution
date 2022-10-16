using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Application.Commands.CreateOperation;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Web.Models
{
    public class CreateOperationDto : IMapWith<CreateOperationCommand>
    {
        [Required]
        //Id топлива
        public Guid FuelId { get; set; }
        [Required]
        //Id емкости
        public Guid TankId { get; set; }
        //Приход/Расход
        public float? Inc_Exp { get; set; }
        [Required]
        //Дата операции
        public DateTime OperationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOperationDto, CreateOperationCommand>()
                .ForMember(operation => operation.TankId,
                    opt => opt.MapFrom(operationDto => operationDto.TankId))
                .ForMember(operation => operation.FuelId,
                    opt => opt.MapFrom(operationDto => operationDto.FuelId))
                .ForMember(operation => operation.Inc_Exp,
                    opt => opt.MapFrom(operationDto => operationDto.Inc_Exp))
                .ForMember(operation => operation.OperationDate,
                    opt => opt.MapFrom(operationDto => operationDto.OperationDate));
        }
    }
}
