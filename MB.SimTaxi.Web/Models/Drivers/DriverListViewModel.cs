using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class DriverListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[Display(Name = "Date of Birth")]
        //public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
