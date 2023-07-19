
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Data.Entities
{
    public class Country
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        public int Id { get; set; }
        public string Title { get; set; }

        [StringLength(8, ErrorMessage = "Code must be between 2 and 8 chars", MinimumLength = 2)]
        public string Code { get; set; }
        public string Capital { get; set; }


        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime Declaration { get; set; }
    }
}
