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
using Curo.DataModel;
using Curo.DataModel;
using Parse;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Curo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        List<curoLists> cLists;
        public MainPage()
        {

         
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            ParseClient.Initialize("ayCw42ToeUszQ6KxmrUgrMM0UWft45N1Bpbpr4aM", "mjImObOldArPtUT9RdozVNVzPbBd9LDbGDAbCVc5");
         
            addtheitems();

        }



        public void addtheitems()
        {
            for (int i = 0; i < 6; i++)
            {
                //Create a new object
                TileClass obj = new TileClass();

                //add the title,notification and source from the sample data
                obj.title = arrayoftitle[i];
                obj.notification = arrayofnotification[i];
                obj.source = "Images/" + imagesource[i];

                //Group them into same category that is give them common tag called tiles
                obj.tag = "Tiles";

                mylistbox.Items.Add(obj);
            }
        }

            public class TileClass
    {


        public string title { get; set; }
        public string notification { get; set; }
        public string source { get; set; }
        public string tag { get; set; }

         

    }

            string[] arrayoftitle = new string[6] { "Flipkart", "Snapdeal", "Jabong", "ebay", "Amazon", "HD" };
            string[] arrayofnotification = new string[6] { "Notify 1", "Notify 2", "Notify 3", "Notify 4", "Notify 5", "Notify 6" };
            string[] imagesource = new string[6] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg" };
 

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.



        }

    
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClientList_Loaded(object sender, RoutedEventArgs e)
        {
        
        }

        private void btnClientList_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof (ClientsManage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ParseUser.CurrentUser != null)
            {
                // do stuff with the user
            }
            else
            {
                Frame.Navigate(typeof(Login));
            }
        }

      
    }
}
