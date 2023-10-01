using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechODayApp.Services;
using TechODayApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechODayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapViewingPage : ContentPage
    {
        DriversViewModel _viewModel;
        public string From;
        public MapViewingPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DriversViewModel();
            Load();
        }
        async private void Load()
        {
            await Navigation.PushAsync(new ClientMain());

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            topLayout.IsVisible = true;
            usersDisplay.IsVisible = true;
            //if (UserProfileState.Instance.IsDriverProfileVisible)
            //{
            //    topLayout.IsVisible = false;
            //    usersDisplay.IsVisible = false;
            //    var request = DataService.Instance.DriveRequest;
            //    // Change UI elements for a driver
            //    var a = DataService.Instance.GetLastItemSimple();
            //    if (request.SelectedDriver == a)
            //    {
            //        var popup = new Popup
            //        {
            //            Content = new StackLayout
            //            {
            //                Children = {
            //                new Label { Text = request.SelectedDriver.DriverName},
            //                new Button{Text = "Accept", Command = new Command(() => Dismiss("Dismiss was clicked")) },
            //                new Button{Text = "Reject", Command = new Command(() => Dismiss("Dismiss was clicked")) }
            //            }
            //            }
            //        };
            //    }
            //}
            //else
            //{
            //    usersDisplay.IsVisible = true;
            //}
            _viewModel.OnAppearing();
        }

        //private void Dismiss(string v)
        //{
        //    throw new NotImplementedException("Here the main coder went to sleep");
        //}
    }
}