using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WPK
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Disabled;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// when the login is correct it open the customers page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginModule_LoginCompleted(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(Customers));
        }
    }
}
