using AutoMapper;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Passengers;

namespace MB.SimTaxi.Web.AutoMapperProfiles
{
    public class PassengerAutoMapperProfile : Profile
    {
        public PassengerAutoMapperProfile()
        {
            CreateMap<Passenger, PassengerListViewModel>();
            CreateMap<Passenger, PassengerDetailsViewModel>();
        }
    }
}
