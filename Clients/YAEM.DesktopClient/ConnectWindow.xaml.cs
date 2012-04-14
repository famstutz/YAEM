// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectWindow.xaml.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ConnectWindow"/> class.
        /// </summary>
        public ConnectWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Joins the button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void JoinButtonClick(object sender, RoutedEventArgs e)
        {
            var messagingWindow = new MessagingWindow(this.NameTextBox.Text);
            Application.Current.MainWindow = messagingWindow;
            messagingWindow.Show();
            this.Close();
        }
    }
}
