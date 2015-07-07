using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Curo.DataModel;
using Curo.DataModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Curo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientsManage : Page
    {


        List<curoLists> cLists;
        curoListsDal _db = new curoListsDal();

        public   ClientsManage()
        {
            this.InitializeComponent();

            PopulatelistAsync();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

   
        public async Task PopulatelistAsync()
        {
            try
            {
                

                cLists = await _db.GetListsAync();

                

                listView.ItemsSource = cLists;

                      
            }
            catch (Exception ex)
            {
            }

        }

        private void btnRfresh_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopulatelistAsync();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            curoLists myobject = listView.SelectedItem as curoLists;
            Frame.Navigate(typeof(ClientManageEdit), myobject);

        }
 
        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChatMessage));

        }

    }
}
