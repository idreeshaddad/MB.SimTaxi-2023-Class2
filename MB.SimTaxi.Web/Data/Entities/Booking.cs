namespace MB.SimTaxi.Web.Data.Entities
{
    public class Booking
    {
        public Booking()
        {
            Passengers = new List<Passenger>();    
        }

        public int Id { get; set; }
        public DateTime PickupDateTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }

        public bool IsPaid { get; set; } // true => مدفوعة

        public DateTime? PaymentDate { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }


        public int? DriverId { get; set; }
        public Driver Driver { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}
