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
            CreateMap<Booking, BookingDetailsViewModel>();

            CreateMap<CreateUpdateBookingViewModel, Booking>();

            CreateMap<Booking, CreateUpdateBookingViewModel>()
                .ForMember(dest => dest.PassengerIds,
                        opts => opts.MapFrom(src => src.Passengers.Select(passenger => passenger.Id).ToList()));
        }
    }
}
