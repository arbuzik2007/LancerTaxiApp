using TechODayApp.Views;
using Xamarin.Forms;

namespace TechODayApp.ViewModels
{
    public class LoginViewModel
    {
        public Command DriverLoginCommand { get; }
        public Command PassengerLoginCommand { get; }

        public LoginViewModel()
        {
            DriverLoginCommand = new Command(OnDriverLoginClicked);
            PassengerLoginCommand = new Command(OnPassengerLoginClicked);
        }

        private void OnDriverLoginClicked(object obj)
        {
            MessagingCenter.Send<App, string>(App.Current as App, "HideDriverRegister", "");
        }

        private async void OnPassengerLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(MapViewingPage)}");
        }
    }
}
