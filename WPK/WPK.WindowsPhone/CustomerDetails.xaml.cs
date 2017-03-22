using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Calls;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI;
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
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        /// <summary>
        /// declared the datacontent of the customers.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            info = (CustomerInfo)e.Parameter;
            InitLocation();
            lbl_Name.DataContext = info;
            lbl_Phone.DataContext = info;
            lbl_adress.DataContext = info;
        }
        /// <summary>
        /// init the locations the phone location and customerlocation.
        /// </summary>
        public async void InitLocation()
        {
            Geolocator geolocator = new Geolocator();
            Geoposition currentPosition;
            IAsyncOperation<Geoposition> async_CurLoc = geolocator.GetGeopositionAsync();
            IAsyncOperation<MapLocationFinderResult> findloc = MapLocationFinder.FindLocationsAsync(
              info.FullAdress, new Geopoint(new BasicGeoposition()));

            Geopoint startPoint;
            MapLocationFinderResult result;
            // icon for the customer.
            MapIcon cusIcon = new MapIcon();
            cusIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            cusIcon.Title = info.Name;
            cusIcon.ZIndex = -100;
            result = await findloc;
            startPoint = result.Locations[0].Point;
            point = startPoint;
            cusIcon.Location = startPoint;
            mapview.MapElements.Add(cusIcon);
            currentPosition = await async_CurLoc;

            //ellipse  for  customer location.
            Ellipse cusLoc = new Ellipse();
            cusLoc.Width = 20;
            cusLoc.Height = 20;
            cusLoc.Stroke = new SolidColorBrush(Colors.Black);
            cusLoc.StrokeThickness = 3;
            MapControl.SetLocation(cusLoc, startPoint);
            MapControl.SetNormalizedAnchorPoint(cusLoc, new Point(0.5, 0.5));
            mapview.Children.Add(cusLoc);

            // zoom level and center
            mapview.Center = startPoint;
            mapview.ZoomLevel = 10;
            
            //ellipse for current location.
            Ellipse curLoc = new Ellipse();
            curLoc.Width = 20;
            curLoc.Height = 20;
            curLoc.Stroke = new SolidColorBrush(Colors.DarkCyan);
            curLoc.StrokeThickness = 3;
            MapControl.SetLocation(curLoc, currentPosition.Coordinate.Point);
            MapControl.SetNormalizedAnchorPoint(curLoc, new Point(0.5, 0.5));
            mapview.Children.Add(curLoc);
        }
        /// <summary>
        /// event is called when lbl_adress is double tapped
        /// is give a promp to open a navigation app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_adress_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Navigate(point, info.Name);
        }
        /// <summary>
        /// calls navigation app with de parameters.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="name"></param>
        private async void Navigate(Geopoint point, string name)
        {
            Uri driveToUri = new Uri(String.Format(
     "ms-drive-to:?destination.latitude={0}&destination.longitude={1}&destination.name={2}",
     point.Position.Latitude,
     point.Position.Longitude,
     name));
           await Windows.System.Launcher.LaunchUriAsync(driveToUri);
        }
        /// <summary>
        /// events is called when lbl_phone is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_Phone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PhoneCallManager.ShowPhoneCallUI(info.FormatPhoneNumber, info.Name);
        }
    }
}
