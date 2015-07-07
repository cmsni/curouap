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
using Parse;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Curo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs n)
        {
            try
            {
                await ParseUser.LogInAsync("buckd", "12345");
            }
            catch (Exception e)
            {
                // The login failed. Check the error to see why.
            }

        }

        private async void btnRegister_Click(object sender, RoutedEventArgs s)
        {
            try
            {
                var user = new ParseUser()
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                await user.SignUpAsync();
            }
            catch (Exception e)
            {
                // The login failed. Check the error to see why.
            }
        }
    }
}
