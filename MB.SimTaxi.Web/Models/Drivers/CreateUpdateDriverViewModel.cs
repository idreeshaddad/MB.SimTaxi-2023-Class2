using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class CreateUpdateDriverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
    }
}
