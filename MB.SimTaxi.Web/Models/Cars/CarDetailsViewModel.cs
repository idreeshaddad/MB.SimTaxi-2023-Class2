using MB.SimTaxi.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Cars
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        [Display(Name = "Car Type")]
        public CarType CarType { get; set; }

        [Display(Name = "Fuel Type")]
        public string FuelTypeName { get; set; }

        [Display(Name = "Driver")]
        public string DriverName { get; set; }
    }
}
