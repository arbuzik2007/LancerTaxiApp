using Android.Graphics;
using TechODayApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TechODayApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterFontAwesome();
            DependencyService.Register<DriverDataService>();
            DependencyService.Register<ClientDataService>();
            MainPage = new AppShell();
        }

        private void RegisterFontAwesome()
        {
            var fontAwesomeFont = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "FontAwesome.otf");
            Resources.Add("FontAwesome", fontAwesomeFont);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
