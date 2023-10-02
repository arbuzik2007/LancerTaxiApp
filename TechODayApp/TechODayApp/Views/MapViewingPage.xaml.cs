using System;
using TechODayApp.Services;
using TechODayApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechODayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapViewingPage : ContentPage
    {
        MapViewModel _viewModel;
        public MapViewingPage()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            _viewModel = new MapViewModel();
            this.BindingContext = _viewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }

        private void rideButton_Clicked(object sender, EventArgs e)
        {
            if (UserProfileState.Instance.IsDriverProfileVisible)
            {
                DisplayAlert("Wrong Action", $"Signed in as driver", "OK");
            }
            else
            {
                _viewModel.SaveCommand.Execute(null);
                Navigation.PushAsync(new ClientMain());
            }
        }
    }
}