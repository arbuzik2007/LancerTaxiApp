using TechODayApp.ViewModels;

namespace TechODayApp.Services
{
    public class DataService
    {
        private static DataService instance;

        // Private constructor to prevent external instantiation
        private DataService()
        {
            DriverProfileViewModel = new DriverProfileViewModel();
            PassengerProfileViewModel = new PassengerProfileViewModel();
            UserProfileState = new UserProfileState();
        }

        public static DataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataService();
                }
                return instance;
            }
        }
        public UserProfileState UserProfileState { get; set; }
        public DriverProfileViewModel DriverProfileViewModel { get; set; }
        public PassengerProfileViewModel PassengerProfileViewModel { get; set;}
    }
}
