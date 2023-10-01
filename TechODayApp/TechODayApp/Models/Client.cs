using System.Collections.ObjectModel;

namespace TechODayApp.Models
{
    public class Client
    {
        public static int RatingDefault = 3;
        public string Id { get; set; } //Guid.NewGuid().ToString()
        public string ClientName { get; set; }
        public string ClientLocation { get; set; }
        public string ClientDestination { get; set; }
        public int Rating { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }
    }
}
