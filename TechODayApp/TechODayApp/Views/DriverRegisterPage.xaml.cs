using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DriverProfilePage(viewModel));
        }
    }
}