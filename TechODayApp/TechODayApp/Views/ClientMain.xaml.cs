using Android.Media;
using System;
using System.Collections.Generic;
using TechODayApp.Models;
using TechODayApp.Services;
using TechODayApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TechODayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientMain : ContentPage
    {
        DriversViewModel _viewModel;
        public ClientMain()
        {
            _viewModel = new DriversViewModel();
            BindingContext = _viewModel;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            UpdateData();
        }

        // Load data into the UI elements

        private void UpdateData()
        {
            var current = ClientDataService.Instance.GetLastItemSimple();

            if (current == null)
                throw new Exception("Error: Client not found");

            currentPosition.Text = current.ClientLocation; 
            destination.Text = current.ClientDestination; 

            _viewModel.UpdateDriverInfos();


            driverList.ItemsSource = _viewModel.DriverInfos;
        }

        // Handle "Take a ride" button click
        private void TakeRideButton_Clicked(object sender, EventArgs e)
        {
            if (driverList.SelectedItem != null)
            {
                var selectedDriver = (DriverInfo)driverList.SelectedItem;
                DisplayAlert("Ride Initiated", $"Ride initiated with {selectedDriver.Name}!", "OK");
            }
            else
            {
                DisplayAlert("Select a Driver", "Please select a driver before taking a ride.", "OK");
            }


            UpdateData();
        }
    }
}