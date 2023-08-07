using AutoMapper;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Cars;

namespace MB.SimTaxi.Web.AutoMapperProfiles
{
    public class CarAutoMapperProfile : Profile
    {
        public CarAutoMapperProfile()
        {
            CreateMap<Car, CarListViewModel>();
            CreateMap<CreateUpdateCarViewModel, Car>().ReverseMap();
            CreateMap<Car, CarDetailsViewModel>();
        }
    }
}
