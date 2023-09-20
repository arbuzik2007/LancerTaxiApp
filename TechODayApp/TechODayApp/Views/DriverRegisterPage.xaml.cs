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
    public partial class DriverRegisterPage : ContentPage
    {
        DriverProfileViewModel viewModel;
        public DriverRegisterPage()
        {
            InitializeComponent();
            viewModel = (DriverProfileViewModel)this.BindingContext;
            sendButton.BackgroundColor = Color.Salmon;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (viewModel.AreFilled())
            {
                viewModel.IsDriverProfileVisible = true;

                var dataService = DataService.Instance;
                // Access properties or methods of the DataService
                dataService.DriverProfileViewModel = viewModel;

                MessagingCenter.Send<App, string>(App.Current as App, "DriverEnter", "");
                
            }
            
            
        }

        void Entry_Completed(object sender, EventArgs e)
        {
            if (viewModel.AreFilled())
                sendButton.BackgroundColor = Color.LightGreen;
        }
    }
}