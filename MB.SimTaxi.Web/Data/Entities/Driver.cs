using MB.SimTaxi.Web.Enums;

namespace MB.SimTaxi.Web.Data.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string SSN { get; set; }
    }
}
