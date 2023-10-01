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
            var passengerProfile = ClientDataService.Instance.passengerProfile;
            passengerProfileItem.IsVisible = true;
            passengerProfile.Reset();

            driverProfileItem.IsVisible = false;
            driverMainItem.IsVisible = false;

            UserProfileState.Instance.IsDriverProfileVisible = false;


            await Shell.Current.GoToAsync("//LoginPage");

            MessagingCenter.Subscribe<App, string>(App.Current, "DriverEnter", (snd, arg) =>
            {
                var state = UserProfileState.Instance.IsDriverProfileVisible = true;
                driverProfileItem.IsVisible = state;
                driverMainItem.IsVisible = state;
                passengerProfileItem.IsVisible = !state;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Shell.Current.GoToAsync($"//{nameof(DriverMain)}");
                });
            });
            MessagingCenter.Subscribe<App, string>(App.Current, "ClientEnter", (snd, arg) =>
            {
                var state = UserProfileState.Instance.IsDriverProfileVisible = false;
                driverProfileItem.IsVisible = state;
                driverMainItem.IsVisible = state;
                passengerProfileItem.IsVisible = !state;
                //Device.BeginInvokeOnMainThread(() =>
                //{
                //    Shell.Current.GoToAsync($"//{nameof(MapViewingPage)}");
                //});
            });
        }

    }
}
