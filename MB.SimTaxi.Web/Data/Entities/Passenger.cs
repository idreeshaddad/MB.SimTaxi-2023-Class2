using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.SimTaxi.Web.Data.Entities
{
    public class Passenger
    {
        public Passenger()
        {
            Bookings = new List<Booking>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Booking> Bookings { get; set; }

        //############### NOT Real columns in the database ########################

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
    }
}
