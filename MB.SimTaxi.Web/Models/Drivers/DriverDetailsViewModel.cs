using MB.SimTaxi.Web.Enums;
using MB.SimTaxi.Web.Models.Cars;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class DriverDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        public List<CarListViewModel> Cars { get; set; }
    }
}
