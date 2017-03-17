using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Calls;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI;
using System.Diagnostics;
using Windows.UI.Xaml.Shapes;

namespace WPK
{
    public sealed partial class CustomerDetails : Page
    {
        CustomerInfo info;
        Geopoint point;
        public CustomerDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            info = (CustomerInfo)e.Parameter;
            info = dbHandler.GetCustomers()[0];
            InitLocation();
        }
        public async void InitLocation()
        {
            Geolocator geolocator = new Geolocator();
            Geoposition currentPosition;
            IAsyncOperation<Geoposition> x = geolocator.GetGeopositionAsync();
            IAsyncOperation<MapLocationFinderResult> findloc = MapLocationFinder.FindLocationsAsync(
              "Aaksterlaan 6, 2691 KP 's-Gravenzande nederland", new Geopoint(new BasicGeoposition()));

            Geopoint startPoint;
            MapLocationFinderResult result;

            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = info.Name;
            mapIcon1.ZIndex = 0;
            result = await findloc;
            startPoint = result.Locations[0].Point;
            point = startPoint;
            mapIcon1.Location = startPoint;
            mapview.MapElements.Add(mapIcon1);
            currentPosition = await x;

            mapview.Center = currentPosition.Coordinate.Point;
            mapview.ZoomLevel = 10;

            Ellipse curLoc = new Ellipse();
            curLoc.Width = 20;
            curLoc.Height = 20;
            curLoc.Stroke = new SolidColorBrush(Colors.DarkCyan);
            curLoc.StrokeThickness = 3;
            MapControl.SetLocation(curLoc, currentPosition.Coordinate.Point);
            MapControl.SetNormalizedAnchorPoint(curLoc, new Point(0.5, 0.5));
            mapview.Children.Add(curLoc);
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PhoneCallManager.ShowPhoneCallUI(info.PhoneNumber, info.Name);
        }

        private void lbl_adress_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Navigate(point, info.Name);
        }
        private async void Navigate(Geopoint point, string name)
        {
            Uri driveToUri = new Uri(String.Format(
     "ms-drive-to:?destination.latitude={0}&destination.longitude={1}&destination.name={2}",
     point.Position.Latitude,
     point.Position.Longitude,
     name));
           await Windows.System.Launcher.LaunchUriAsync(driveToUri);
        }
    }
}
