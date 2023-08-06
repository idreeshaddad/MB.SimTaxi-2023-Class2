using MB.SimTaxi.Web.Enums;
using MB.SimTaxi.Web.Models.FuelTypes;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Web.Models.Cars
{
    public class CreateUpdateCarViewModel
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
        public int FuelTypeId { get; set; }

        [Display(Name = "Driver")]
        public int DriverId { get; set; }
    }
}
