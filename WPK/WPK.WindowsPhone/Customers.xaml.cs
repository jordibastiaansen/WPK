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

namespace WPK
{
    public sealed partial class Customers : Page
    {
        private List<CustomerInfo> cusList;

        public Customers()
        {
            this.InitializeComponent();
            cusList = dbHandler.GetCustomers();
            mylistbox.ItemsSource = cusList;
        }

        private void SearchList(string searchquery)
        {
            mylistbox.ItemsSource = cusList.Where(w => w.Name.ToLower().Contains(searchquery.ToLower()));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearchBar.Text != "")
                SearchList(txtSearchBar.Text);
            else
                mylistbox.ItemsSource = cusList;
        }
        private void OpenCustomer(object sender, SelectionChangedEventArgs e)
        {
            CustomerInfo selectedInfo = (sender as ListBox).SelectedItem as CustomerInfo;
            Frame.Navigate(typeof(CustomerDetails), selectedInfo);
        }
    }
}
