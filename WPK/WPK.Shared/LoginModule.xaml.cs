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
using Windows.UI.Popups;
using System.Diagnostics;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WPK
{
    public  partial class LoginModule : UserControl
    {
        public LoginModule()
        {
            this.InitializeComponent();
        }
        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (dbHandler.Login(txt_UserName.Text, txt_Password.Password))
                OnLoginCompleted(true);
            else
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        public event EventHandler LoginCompleted;
        protected  void OnLoginCompleted(bool authenticated)
        {
            if (LoginCompleted != null)
                LoginCompleted(this, new LoginEventArgs(authenticated));
        }
    }
    public class LoginEventArgs : EventArgs
    {
        private bool authenticated;

        public LoginEventArgs(bool authenticated)
        {
            this.authenticated = authenticated;
        }
        public bool Authenticated
        {
            get { return this.authenticated; }
        }
    }
}
