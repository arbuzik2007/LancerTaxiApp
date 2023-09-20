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
    public partial class PassengerProfilePage : ContentPage
    {
        PassengerProfileViewModel _viewModel;
        public PassengerProfilePage()
        {
            InitializeComponent();
            _viewModel = DataService.Instance.PassengerProfileViewModel;
            BindingContext = _viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DataService.Instance.PassengerProfileViewModel = _viewModel;
            if (!String.IsNullOrEmpty(tagEntry.Text))
                _viewModel.AddTag(tagEntry.Text);
        }
    }
}