using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WPK
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customers : Page
    {
        private CustomerInfo[] cusList;

        public Customers()
        {
            this.InitializeComponent();
            cusList = dbHandler.GetCustomers();
            mylistbox.ItemsSource = cusList;
        }

        private void SearchList(string searchquery)
        {
            mylistbox.ItemsSource = cusList.Where(w => w.name.ToLower().Contains(searchquery));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearchBar.Text != "")
            {
                SearchList(txtSearchBar.Text);
            }
            else
            {
                mylistbox.ItemsSource = cusList;
            }
        }

        private void OpenCustomer(object sender, SelectionChangedEventArgs e)
        {
            CustomerInfo selectedInfo = (sender as ListBox).SelectedItem as CustomerInfo;
            Debug.WriteLine("Tapped a customer.");
            Frame.Navigate(typeof(CustomerDetails), selectedInfo);
        }
    }
}
