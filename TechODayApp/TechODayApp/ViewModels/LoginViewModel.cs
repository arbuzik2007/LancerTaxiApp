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
            //made inside the LoginPage.xaml using Navigator
        }

        private async void OnPassengerLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(PassengerProfilePage)}");
        }
    }
}
