using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Countries
{
    public class CountryViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Full Name")]
        public string Name { get; set; }


        [StringLength(8, ErrorMessage = "Code must be between 2 and 8 chars", MinimumLength = 2)]
        public string Code { get; set; }
    }
}
