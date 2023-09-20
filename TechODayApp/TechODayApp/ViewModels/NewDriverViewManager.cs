using System;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;
using TechODayApp.Models;
using TechODayApp.Services;
using System.Diagnostics;

namespace TechODayApp.ViewModels
{
    public class NewDriverViewManager : BaseViewModel
    {
        private string driverName;
        private string carModel;
        private string carBrand;
        private string plateNumber;

        public NewDriverViewManager()
        {
            SaveCommand = new Command(OnSave, AreFilled);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string DriverName
        {
            get => driverName;
            set => SetProperty(ref driverName, value);
        }
        public string CarBrand
        {
            get => carBrand;
            set => SetProperty(ref carBrand, value);
        }

        public string PlateNumber
        {
            get => plateNumber;
            set => SetProperty(ref  plateNumber, value);
        }

        public string CarModel
        {
            get => carModel;
            set => SetProperty(ref carModel, value);
        }

        public bool AreFilled()
        {
            if(!String.IsNullOrEmpty(CarBrand) &&
                !String.IsNullOrEmpty(CarModel) &&
                !String.IsNullOrEmpty(DriverName) &&
                !String.IsNullOrEmpty(PlateNumber))
                return true;
            return false;
        }

        public void Reset()
        {
            DriverName = String.Empty;
            CarBrand = String.Empty;
            CarModel = String.Empty;
            PlateNumber = String.Empty;
        }

        public Command SaveCommand { get; }

        private async void OnSave()
        {
            Driver newItem = new Driver()
            {
                DriverName = driverName,
                CarBrand = carBrand,
                CarModel = carModel,
                PlateNumber = plateNumber
            };

            await DataStore.AddItemAsync(newItem);

            MessagingCenter.Send<App, string>(App.Current as App, "DriverEnter", "");

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public async void LoadItem()
        {
            try
            {
                var item = await DataStore.GetLastItem();
                DriverName = item.DriverName;
                CarBrand = item.CarBrand;
                CarModel = item.CarModel;
                PlateNumber = item.PlateNumber;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
