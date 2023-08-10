using MB.SimTaxi.Web.Enums;

namespace MB.SimTaxi.Web.Data.Entities
{
    public class Driver
    {
        public Driver()
        {
            Cars = new List<Car>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; } // Sameer
        public string LastName { get; set; } // Bino
        public string FullName // Sameer Bino
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }


        public DateTime DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string SSN { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public List<Car> Cars { get; set; }

        
    }
}
