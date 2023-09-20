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
    public partial class DriverProfilePage : ContentPage
    {
        public DriverProfilePage()
        {
            InitializeComponent();
            var _viewModel = new NewDriverViewManager();
            _viewModel.LoadItem();
            BindingContext = _viewModel;
        }

        //public DriverProfilePage(DriverProfileViewModel viewModel)
        //{
        //    InitializeComponent();
        //    BindingContext = viewModel;
        //}
    }
}