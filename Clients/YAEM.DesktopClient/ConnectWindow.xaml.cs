using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YAEM.DesktopClient
{
    /// <summary>
    /// Interaction logic for ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        public ConnectWindow()
        {
            InitializeComponent();
        }

        private void JoinButtonClick(object sender, RoutedEventArgs e)
        {
            var messagingWindow = new MessagingWindow(this.NameTextBox.Text);
            Application.Current.MainWindow = messagingWindow;
            messagingWindow.Show();
            this.Close();
        }
    }
}
