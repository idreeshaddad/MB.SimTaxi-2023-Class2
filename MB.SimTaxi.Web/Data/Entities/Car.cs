using MB.SimTaxi.Web.Enums;
using System.ComponentModel;

namespace MB.SimTaxi.Web.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public CarType CarType { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
