using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
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
            mylistbox.ItemsSource = cusList;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
        }

        /// <summary>
        /// search the list with the parameter.
        /// </summary>
        /// <param name="searchquery"></param>
        private void SearchList(string searchquery)
        {
            IEnumerable<CustomerInfo> searchResult = cusList.Where(w => w.Name.ToLower().Contains(searchquery.ToLower()));
            mylistbox.ItemsSource = searchResult;
            lbl_NoResult.Visibility =(searchResult.Count() <= 0 ? Visibility.Visible : Visibility.Collapsed);
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
            CustomerInfo selectedInfo = (CustomerInfo)((ListBox)sender).SelectedItem;
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
                CustomerInfo selectedInfo = (CustomerInfo)((ListBox)sender).SelectedItem;
                if (selectedInfo != null)
                    Frame.Navigate(typeof(CustomerDetails), selectedInfo);
            }
            clicked = false;
        }
    }
}
