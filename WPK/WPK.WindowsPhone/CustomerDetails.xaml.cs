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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WPK
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerDetails : Page
    {
        private CustomerInfo info;
        public CustomerDetails()
        { 
            this.InitializeComponent();
            test();
           // PhoneCallManager.ShowPhoneCallUI("06-12345678", "test");
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            info = (CustomerInfo)e.Parameter;
        }

        public async void test()
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
            mapIcon1.Title = "wpk";
            mapIcon1.ZIndex = 0;
            result = await findloc;
            startPoint = result.Locations[0].Point;
            mapIcon1.Location = startPoint;
            mapview.MapElements.Add(mapIcon1);
            currentPosition = await x;

            mapview.Center = currentPosition.Coordinate.Point;
            mapview.ZoomLevel = 10;

            Ellipse curLoc =  new Ellipse();
            curLoc.Width = 20;
            curLoc.Height = 20;
            curLoc.Stroke = new SolidColorBrush(Colors.DarkCyan);
            curLoc.StrokeThickness = 3;
            MapControl.SetLocation(curLoc, currentPosition.Coordinate.Point);
            MapControl.SetNormalizedAnchorPoint(curLoc, new Point(0.5, 0.5));
            mapview.Children.Add(curLoc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test();
        }
    }
}
