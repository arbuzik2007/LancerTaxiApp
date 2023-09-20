using System;
using TechODayApp.Services;
using TechODayApp.Views;
using Xamarin.Forms;

namespace TechODayApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var passengerProfile = DataService.Instance.PassengerProfileViewModel;
            passengerProfileItem.IsVisible = true;
            passengerProfile.Reset();

            var driverProfile = DataService.Instance.DriverProfileViewModel;
            driverProfileItem.IsVisible = false;
            driverProfile.Reset();

            await Shell.Current.GoToAsync("//LoginPage");

            MessagingCenter.Subscribe<App, string>(App.Current, "DriverEnter", (snd, arg) =>
            {
                driverProfileItem.IsVisible = DataService.Instance.DriverProfileViewModel.IsDriverProfileVisible;
                passengerProfileItem.IsVisible = !driverProfileItem.IsVisible;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Shell.Current.GoToAsync($"//{nameof(MapViewingPage)}");
                });
            });
        }

    }
}
