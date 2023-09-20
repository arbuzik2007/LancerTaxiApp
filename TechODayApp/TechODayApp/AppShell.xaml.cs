using System;
using TechODayApp.Services;
using TechODayApp.ViewModels;
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

            driverProfileItem.IsVisible = false;


            UserProfileState.Instance.IsDriverProfileVisible = false;


            await Shell.Current.GoToAsync("//LoginPage");

            MessagingCenter.Subscribe<App, string>(App.Current, "DriverEnter", (snd, arg) =>
            {
                var state = UserProfileState.Instance.IsDriverProfileVisible = true;
                driverProfileItem.IsVisible = state;
                passengerProfileItem.IsVisible = !driverProfileItem.IsVisible;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Shell.Current.GoToAsync($"//{nameof(MapViewingPage)}");
                });
            });
        }

    }
}
