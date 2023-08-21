using AutoMapper;
using FuelStation.Application.Commands.CreateFuel;
using FuelStation.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Web.Models
{
    public class CreateFuelDto : IMapWith<CreateFuelCommand>
    {
        [Required]
        //Название топлива
        public string FuelType { get; set; } = null!;
        //Плотность топлива
        public float FuelDensity { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFuelDto, CreateFuelCommand>()
                .ForMember(fuelCommand => fuelCommand.FuelType,
                    opt => opt.MapFrom(FuelDto => FuelDto.FuelType))
                .ForMember(fuelCommand => fuelCommand.FuelDensity,
                    opt => opt.MapFrom(FuelDto => FuelDto.FuelDensity));
        }
    }
}
