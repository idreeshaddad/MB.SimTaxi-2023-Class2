using AutoMapper;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Drivers;

namespace MB.SimTaxi.Web.AutoMapperProfiles
{
    public class DriverAutoMapperProfile : Profile
    {
        public DriverAutoMapperProfile()
        {
            CreateMap<CreateUpdateDriverViewModel, Driver>().ReverseMap();
            CreateMap<Driver, DriverListViewModel>();
            CreateMap<Driver, DriverDetailsViewModel>();
        }
    }
}
