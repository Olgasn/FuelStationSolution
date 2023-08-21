using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Domain;

namespace FuelStation.Application.Queries.GetDetails
{
    public class FuelDetailsVm : IMapWith<Fuel>
    {
        //Id Топлива
        public Guid Id { get; set; }
        //Название вида топлива
        public string FuelType { get; set; } = null!;
        //Плотность вида топлива
        public float FuelDensity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fuel, FuelDetailsVm>()
                .ForMember(fuelVm => fuelVm.FuelType,
                    opt => opt.MapFrom(Fuel => Fuel.FuelType))
                .ForMember(fuelVm => fuelVm.Id,
                    opt => opt.MapFrom(Fuel => Fuel.Id))
                .ForMember(fuelVm => fuelVm.FuelDensity,
                    opt => opt.MapFrom(Fuel => Fuel.FuelDensity))
               ;
        }
    }
}
