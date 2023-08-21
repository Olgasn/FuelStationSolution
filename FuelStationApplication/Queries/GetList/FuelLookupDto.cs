using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Domain;

namespace FuelStation.Application.Queries.GetList
{
    public class FuelLookupDto : IMapWith<Fuel>
    {
        //Id Топлива
        public Guid Id { get; set; }
        //Название вида топлива
        public string FuelType { get; set; } = null!;
        //Плотность вида топлива
        public float FuelDensity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fuel, FuelLookupDto>()
                .ForMember(FuelDto => FuelDto.Id,
                    opt => opt.MapFrom(Fuel => Fuel.Id))
                .ForMember(FuelDto => FuelDto.FuelType,
                    opt => opt.MapFrom(Fuel => Fuel.FuelType))
                .ForMember(FuelDto => FuelDto.FuelDensity,
                    opt => opt.MapFrom(Fuel => Fuel.FuelDensity));
        }
    }
}
