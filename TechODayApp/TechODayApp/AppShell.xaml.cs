using System;
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
            await Shell.Current.GoToAsync("//LoginPage");
            MessagingCenter.Subscribe<App, string>(App.Current, "HideDriverRegister", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    Shell.Current.GoToAsync($"//{nameof(DriverRegisterPage)}");

                    driverRegisterItem.IsVisible = true;
                });
            });
        }

    }
}
