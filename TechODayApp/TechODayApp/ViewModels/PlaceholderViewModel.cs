namespace TechODayApp.ViewModels
{
    public class PlaceholderViewModel
    {
        public PlaceholderViewModel(string driverName, string carModel, string carBrand, string plateNumber) {
            DriverName = driverName;
            CarModel = carModel;
            CarBrand = carBrand;
            PlateNumber = plateNumber;
        }

        public static string DriverName { get; private set; } = $"{nameof(DriverName)}";
        public static string CarModel { get; private set; } = $"{nameof(CarModel)}";
        public static string CarBrand { get; private set; } = $"{nameof(CarBrand)}";
        public static string PlateNumber { get; private set; } = $"{nameof(PlateNumber)}";
    }
}
