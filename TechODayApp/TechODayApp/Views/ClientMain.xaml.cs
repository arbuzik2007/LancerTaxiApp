using Android.Media;
using System;
using System.Collections.Generic;
using TechODayApp.Models;
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

            currentPosition.Text = "123 Main St"; // Replace with actual data
            destination.Text = "456 Elm St"; // Replace with actual data

            _viewModel.UpdateDriverInfos();

            //List<ViewCell> cells = new List<ViewCell>();

            //foreach (var item in _drivers)
            //{
            //    var mainCell = new ViewCell();
            //    var stackLayout = new StackLayout();

            //    var frame = new Frame() { HasShadow = true, Margin = 5, CornerRadius = 8, BackgroundColor = Color.FromHex("#79AC78") }; //green background
            //    var contentLayout = new StackLayout() { Orientation = StackOrientation.Horizontal, Padding = 10 };

            //    contentLayout.Children.Add(new Label { Text=item.Name, VerticalOptions = LayoutOptions.CenterAndExpand });
            //    contentLayout.Children.Add(new Label { Text = item.StarRating, VerticalOptions = LayoutOptions.CenterAndExpand });

            //    frame.Content = contentLayout;

            //    stackLayout.Children.Add(frame);
            //    mainCell.View = stackLayout;
            //    cells.Add(mainCell);
            //}


            driverList.ItemsSource = _viewModel.DriverInfos;

            //driverList.SetBinding(ListView.ItemsSourceProperty, nameof(_drivers));

            //driverList.ItemsSource = _drivers;
        }

        // Handle "Take a ride" button click
        private void TakeRideButton_Clicked(object sender, EventArgs e)
        {
            if (driverList.SelectedItem != null)
            {
                var selectedDriver = (Driver)driverList.SelectedItem;
                DisplayAlert("Ride Initiated", $"Ride initiated with {selectedDriver.DriverName}!", "OK");
            }
            else
            {
                DisplayAlert("Select a Driver", "Please select a driver before taking a ride.", "OK");
            }

            foreach(var i in _viewModel.DriverInfos)
            {
                Console.Write(i.Name);
            }


            UpdateData();
        }
    }
}