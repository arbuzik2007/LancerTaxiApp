using Syncfusion.SfMaps.XForms;
using Xamarin.Forms;

namespace TechODayApp.MapMarkers
{
    public class CustomMarker : MapMarker
    {
        public ImageSource Image { get; set; }
        public CustomMarker()
        {
            Image = ImageSource.FromResource("MarkerOnGPSLocation.pin.png");
        }
    }
}
