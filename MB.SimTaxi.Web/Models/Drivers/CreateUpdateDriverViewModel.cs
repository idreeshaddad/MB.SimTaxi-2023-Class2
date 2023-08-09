using MB.SimTaxi.Web.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class CreateUpdateDriverViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Full Name")]
        [ValidateNever]
        public string FullName { get; set; }


        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
    }
}
