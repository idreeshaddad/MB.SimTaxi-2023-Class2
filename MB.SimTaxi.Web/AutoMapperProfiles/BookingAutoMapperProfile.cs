using AutoMapper;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Bookings;

namespace MB.SimTaxi.Web.AutoMapperProfiles
{
    public class BookingAutoMapperProfile : Profile
    {
        public BookingAutoMapperProfile()
        {
            CreateMap<Booking, BookingListViewModel>();
            CreateMap<Booking, CreateUpdateBookingViewModel>().ReverseMap();
            CreateMap<Booking, BookingDetailsViewModel>();
        }
    }
}
