using System;
using System.Timers;
using TechODayApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TechODayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverMain : ContentPage
    {
        ClientsViewModel _viewModel;
        public DriverMain()
        {
            InitializeComponent();

            _viewModel = new ClientsViewModel();
            this.BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            //Update Requests Info

            dutyToggle.IsChecked = true;
            updateDriverStatus(null, null);
            dutyToggle.CheckedChanged += updateDriverStatus;


            

        }

        private void updateDriverStatus(object sender, CheckedChangedEventArgs e)
        {
            bool isOnDuty = dutyToggle.IsChecked;
            if (isOnDuty)
            {
                
                requestList.IsVisible = false;
                requestList.Children.Clear();
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
            foreach (var item in _viewModel.Items)
            {
                var stackLayout = new StackLayout();
                var label = new Label() { Text = $"{item.ClientName} - Pickup at {item.ClientLocation} - To {item.ClientDestination}" };
                stackLayout.Children.Add(label);

                var tagLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
                foreach (var tag in item.Tags)
                {
                    tagLayout.Children.Add(new Label() { Text = tag.Name, TextColor = tag.Color });
                }
                stackLayout.Children.Add(tagLayout);

                var gestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 1, Command = _viewModel.ItemTapped };
                stackLayout.GestureRecognizers.Add(gestureRecognizer);

                requestList.Children.Add(stackLayout);
            }
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //RideNow button execution
        }
    }
}