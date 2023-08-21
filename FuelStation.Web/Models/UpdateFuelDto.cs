using AutoMapper;
using FuelStation.Application.Commands.UpdateFuel;
using FuelStation.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Web.Models
{
    public class UpdateFuelDto : IMapWith<UpdateFuelCommand>
    {
        public Guid Id { get; set; }
        [Required]
        //Название топлива
        public string FuelType { get; set; } = null!;
        //Плотность топлива
        public float FuelDensity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFuelDto, UpdateFuelCommand>()
                .ForMember(FuelCommand => FuelCommand.Id,
                    opt => opt.MapFrom(FuelDto => FuelDto.Id))
                .ForMember(FuelCommand => FuelCommand.FuelType,
                    opt => opt.MapFrom(FuelDto => FuelDto.FuelType))
                .ForMember(FuelCommand => FuelCommand.FuelDensity,
                    opt => opt.MapFrom(FuelDto => FuelDto.FuelDensity));
        }
    }
}
