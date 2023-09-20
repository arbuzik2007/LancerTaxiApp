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
        NewDriverViewManager viewModel;
        public DriverRegisterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NewDriverViewManager();
            //viewModel = (NewDriverViewManager)this.BindingContext;
            sendButton.BackgroundColor = Color.Salmon;
        }

        void Entry_Completed(object sender, EventArgs e)
        {
            if (viewModel.AreFilled())
                sendButton.BackgroundColor = Color.LightGreen;
        }
    }
}