using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Passengers
{
    public class PassengerListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }
}
