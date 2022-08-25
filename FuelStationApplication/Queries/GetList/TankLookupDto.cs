using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Domain;

namespace FuelStation.Application.Queries.GetList
{
    public class TankLookupDto : IMapWith<Tank>
    {
        public Guid Id { get; set; }
        public string TankType { get; set; } = null!;
        //Объем емкости
        public float TankVolume { get; set; }
        //Вес емкости
        public float TankWeight { get; set; }
        //Материал емкости
        public string? TankMaterial { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tank, TankLookupDto>()
                .ForMember(tankDto => tankDto.Id,
                    opt => opt.MapFrom(tank => tank.Id))
                .ForMember(tankDto => tankDto.TankType,
                    opt => opt.MapFrom(tank => tank.TankType))
                .ForMember(tankDto => tankDto.TankVolume,
                    opt => opt.MapFrom(tank => tank.TankVolume));
        }
    }
}
