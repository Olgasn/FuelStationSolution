using AutoMapper;
using FuelStation.Application.Common.Mappings;
using FuelStation.Domain;

namespace FuelStation.Application.Queries.GetDetails
{
    public class TankDetailsVm : IMapWith<Tank>
    {
        //ID емкости
        public Guid Id { get; set; }
        //Тип емкости
        public string TankType { get; set; } = null!;
        //Вес емкости
        public float TankWeight { get; set; }
        //Объем емкости
        public float TankVolume { get; set; }
        //Материал емкости
        public string TankMaterial { get; set; } = null!;
        //Ссылка на изображение емкости
        public string? TankPicture { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tank, TankDetailsVm>()
                .ForMember(tankVm => tankVm.TankType,
                    opt => opt.MapFrom(tank => tank.TankType))
                .ForMember(tankVm => tankVm.TankMaterial,
                    opt => opt.MapFrom(tank => tank.TankMaterial))
                .ForMember(tankVm => tankVm.Id,
                    opt => opt.MapFrom(tank => tank.Id))
                .ForMember(tankVm => tankVm.TankWeight,
                    opt => opt.MapFrom(tank => tank.TankWeight))
                .ForMember(tankVm => tankVm.TankVolume,
                    opt => opt.MapFrom(tank => tank.TankVolume))
                .ForMember(tankVm => tankVm.TankPicture,
                    opt => opt.MapFrom(tank => tank.TankPicture));
        }
    }
}
