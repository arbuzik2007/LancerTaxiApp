using System;
using System.Timers;
using TechODayApp.Models;
using TechODayApp.Services;
using TechODayApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechODayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverMain : ContentPage
    {
        ClientsViewModel _viewModel;
        Driver currentDriver;
        public DriverMain()
        {
            InitializeComponent();

            _viewModel = new ClientsViewModel();
            this.BindingContext = _viewModel;

            Load();
        }

        private void Load()
        {
            currentDriver = DriverDataService.Instance.GetLastItemSimple();
            if(currentDriver == null)
                throw new Exception("Error: Driver not found");

            dutyToggle.IsChecked = true;
            updateDriverStatus(null, null);
            dutyToggle.CheckedChanged += updateDriverStatus;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            Load();

        }

        private void updateDriverStatus(object sender, CheckedChangedEventArgs e)
        {
            bool isOnDuty = dutyToggle.IsChecked;
            if (isOnDuty)
            {
                
                requestList.IsVisible = false;
                pickRequestButton.IsVisible = false;

            }
            else
            {
                requestList.IsVisible = true;
                pickRequestButton.IsVisible = true;
                updateRequestList();
            }
            driverStatusMessage.Text = isOnDuty ? "On Duty" : "Out of Service";
            driverStatus.IsVisible = true;
            Timer aTimer = new Timer();
            aTimer.Interval = 3000; //ms
            aTimer.Enabled = true;
            aTimer.AutoReset = false;
            aTimer.Elapsed += ATimer_Elapsed;
        }

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => { driverStatus.IsVisible = false; });
        }

        private void updateRequestList()
        {
            _viewModel.UpdateClientInfos(currentDriver);
            requestList.ItemsSource = _viewModel.ClientInfos;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(requestList.SelectedItem != null)
            {
                var selectedDClient = (ClientInfo)requestList.SelectedItem;
                DisplayAlert("Ride Initiated", $"Ride initiated with {selectedDClient.Name}!", "OK");
            }
            else
            {
                DisplayAlert("Select a Request", "Please select a request before taking a ride.", "OK");
            }
            //RideNow button execution
        }
    }
}