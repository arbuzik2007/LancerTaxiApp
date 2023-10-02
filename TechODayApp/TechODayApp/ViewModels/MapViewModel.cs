using TechODayApp.Services;
using Xamarin.Forms;
using TechODayApp.Views;
using Android.Media;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using TechODayApp.MapMarkers;
using Syncfusion.SfMaps.XForms;

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

        public async void AddMarkerInCurrentLocation(ImageryLayer layer)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    CustomMarker marker = new CustomMarker();
                    marker.Latitude = location.Latitude.ToString();
                    marker.Longitude = location.Longitude.ToString();

                    LocationCallBack = $"lat: {location.Latitude} lon: {location.Longitude}";

                    layer.GeoCoordinates = new Point(location.Latitude, location.Longitude);
                    layer.Radius = 5;
                    layer.DistanceType = DistanceType.KiloMeter;

                    layer.Markers = new ObservableCollection<MapMarker> { marker };
                }
            }
            catch (Exception ex)
            {
                // Handle not supported on device exception
                await Application.Current.MainPage.DisplayAlert("Not Supported", ex.Message, "Ok");
            }
        }
    }
}
