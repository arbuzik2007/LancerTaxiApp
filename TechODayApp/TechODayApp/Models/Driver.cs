using System.Collections.Generic;

namespace TechODayApp.Models
{
    public class Driver
    {
        public static int RatingDefault = 3;
        public string DriverName { get; set; }
        public string CarModel { get; set; }
        public string CarBrand { get; set; }
        public string PlateNumber { get; set; }
        public int Rating { get; set; }

        public List<Client> AssociatedClients { get; set; } = new List<Client>(); // Collection of associated clients
    }
}
