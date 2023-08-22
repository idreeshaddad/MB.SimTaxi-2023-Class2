using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Bookings
{
    public class CreateUpdateBookingViewModel
    {
        public CreateUpdateBookingViewModel()
        {
            PassengerIds = new List<int>();    
        }

        public int Id { get; set; }

        [Display(Name = "Pickup Time")]
        public DateTime PickupDateTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }

        [Display(Name = "Paid")]
        public bool IsPaid { get; set; }


        [Display(Name = "Car")]
        public int? CarId { get; set; }


        [Display(Name = "Driver")]
        public int? DriverId { get; set; }

        [Display(Name = "Passengers")]
        public List<int> PassengerIds { get; set; }

        // #################  Validate Never ONLY for display and select from NOT for submitting #######################

        [ValidateNever]
        public SelectList CarSelectList { get; set; }

        [ValidateNever]
        public SelectList DriverSelectList { get; set; }

        [ValidateNever]
        public MultiSelectList PassengerMultiselectList { get; set; }
    }
}
