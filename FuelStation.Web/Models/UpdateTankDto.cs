using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Application.Commands.UpdateTank;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Web.Models
{
    public class UpdateTankDto : IMapWith<UpdateTankCommand>
    {
        public Guid Id { get; set; }
        [Required]
        //Название емкости
        public string TankType { get; set; } = null!;
        public float TankWeight { get; set; }
        //Объем емкости
        public float TankVolume { get; set; }
        //Материал емкости
        public string TankMaterial { get; set; } = null!;
        //Ссылка на изображение емкости
        public string? TankPicture { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTankDto, UpdateTankCommand>()
                .ForMember(tankCommand => tankCommand.Id,
                    opt => opt.MapFrom(tankDto => tankDto.Id))
                .ForMember(tankCommand => tankCommand.TankType,
                    opt => opt.MapFrom(tankDto => tankDto.TankType))
                .ForMember(tankCommand => tankCommand.TankMaterial,
                    opt => opt.MapFrom(tankDto => tankDto.TankMaterial))
                .ForMember(tankCommand => tankCommand.TankVolume,
                    opt => opt.MapFrom(tankDto => tankDto.TankVolume))
                .ForMember(tankCommand => tankCommand.TankWeight,
                    opt => opt.MapFrom(tankDto => tankDto.TankWeight));
        }
    }
}
