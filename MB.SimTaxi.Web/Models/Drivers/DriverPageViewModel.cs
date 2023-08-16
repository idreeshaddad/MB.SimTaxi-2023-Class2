using MB.SimTaxi.Web.Models.Cars;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class DriverPageViewModel
    {
        public List<DriverListViewModel> Drivers { get; set; }
        public List<CarLookUpViewModel> CarsLookUp { get; set; }
    }
}
