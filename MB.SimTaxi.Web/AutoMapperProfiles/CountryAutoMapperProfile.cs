using AutoMapper;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Countries;

namespace MB.SimTaxi.Web.AutoMapperProfiles
{
    public class CountryAutoMapperProfile : Profile
    {
        public CountryAutoMapperProfile()
        {
            CreateMap<Country, CountryViewModel>().ReverseMap();
        }
    }
}
