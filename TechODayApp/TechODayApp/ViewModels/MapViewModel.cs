using TechODayApp.Services;
using Xamarin.Forms;
using TechODayApp.Views;
using Android.Media;
using System;

namespace TechODayApp.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        public MapViewModel()
        {
            SaveCommand = new Command(OnSave, AreFilled);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        

        private string locationCallBack;
        public string LocationCallBack
        {
            get => locationCallBack;
            set
            {
                SetProperty(ref locationCallBack, value);
            }
        }
        private string directionCallBack;
        public string DirectionCallBack
        {
            get => directionCallBack;
            set
            {
                SetProperty(ref directionCallBack, value);
            }
        }

        public Command SaveCommand { get; }

        private bool AreFilled()
        {
            if (String.IsNullOrEmpty(locationCallBack) ||
                String.IsNullOrEmpty(directionCallBack))
                return false;
            return true;
        }

        private async void OnSave()
        {
            var current = ClientDataService.Instance.GetLastItemSimple();
            current.ClientLocation = locationCallBack;
            current.ClientDestination = directionCallBack;

            await ClientDataService.Instance.UpdateItemAsync(current);
        }
    }
}
