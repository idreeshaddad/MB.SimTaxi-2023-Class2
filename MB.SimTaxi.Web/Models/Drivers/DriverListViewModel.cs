using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class DriverListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        //[Display(Name = "Date of Birth")]
        //public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
