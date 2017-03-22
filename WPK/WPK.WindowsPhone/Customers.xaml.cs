using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
namespace WPK
{
    public sealed partial class Customers : Page
    {
        private List<CustomerInfo> cusList;
        private bool clicked;
        public Customers()
        {
            this.InitializeComponent();
            cusList = dbHandler.GetCustomers();
            mylistbox.ItemsSource = cusList.ToArray();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        /// <summary>
        /// search the list with the parameter.
        /// </summary>
        /// <param name="searchquery"></param>
        private void SearchList(string searchquery)
        {
            IEnumerable<CustomerInfo> searchResult = cusList.Where(w => w.Name.ToLower().Contains(searchquery.ToLower()));
            mylistbox.ItemsSource = searchResult;
            lbl_NoResult.Visibility =(Windows.UI.Xaml.Visibility) (searchResult.Count() <= 0 ? 0 : 1);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearchBar.Text != "")
                SearchList(txtSearchBar.Text);
            else
            {
                mylistbox.ItemsSource = cusList.ToArray();
                lbl_NoResult.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
        /// <summary>
        /// event to open the customerdetails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCustomer(object sender, SelectionChangedEventArgs e)
        {
            clicked = true;
            CustomerInfo selectedInfo = (sender as ListBox).SelectedItem as CustomerInfo;
            if (selectedInfo != null)
            {
                Frame.Navigate(typeof(CustomerDetails), selectedInfo);
            }
        }

        /// <summary>
        /// this event is created for the back fuction when you want to open the same customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mylistbox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!clicked)
            {
                CustomerInfo selectedInfo = (sender as ListBox).SelectedItem as CustomerInfo;
                if (selectedInfo != null)
                    Frame.Navigate(typeof(CustomerDetails), selectedInfo);
            }
            clicked = false;
        }
    }
}
