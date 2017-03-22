using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

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
