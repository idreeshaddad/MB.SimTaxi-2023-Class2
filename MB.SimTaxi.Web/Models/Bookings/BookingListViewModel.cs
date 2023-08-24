using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Bookings
{
    public class BookingListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Pickup Time")]
        public DateTime PickupDateTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }

        [Display(Name = "Paid")]
        public bool IsPaid { get; set; }

        public DateTime? PaymentDate { get; set; }


        [Display(Name = "Car")]
        public string CarTitle { get; set; }


        [Display(Name = "Driver")]
        public string DriverFullName { get; set; }
    }
}
