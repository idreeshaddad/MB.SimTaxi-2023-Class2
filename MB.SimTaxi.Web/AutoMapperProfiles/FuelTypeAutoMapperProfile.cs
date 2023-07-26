using AutoMapper;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.FuelTypes;

namespace MB.SimTaxi.Web.AutoMapperProfiles
{
    public class FuelTypeAutoMapperProfile : Profile
    {
        public FuelTypeAutoMapperProfile()
        {
            CreateMap<FuelType, FuelTypeViewModel>().ReverseMap();
        }
    }
}
