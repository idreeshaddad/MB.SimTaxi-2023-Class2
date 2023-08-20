using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Passengers
{
    public class PassengerDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumnber { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        // TODO show list of bookings
    }
}
