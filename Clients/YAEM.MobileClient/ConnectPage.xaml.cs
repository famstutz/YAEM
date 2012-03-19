using System;

namespace YAEM.MobileClient
{
    using System.Windows;
    using Microsoft.Phone.Controls;

    public partial class ConnectPage : PhoneApplicationPage
    {
        // Constructor
        public ConnectPage()
        {
            InitializeComponent();
        }

        private void JoinButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MessagingPage.xaml?name=" + this.NameTextBox.Text,
                                               UriKind.RelativeOrAbsolute));
        }
    }
}