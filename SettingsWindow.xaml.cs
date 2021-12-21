/********************************************//**
 *  Filename: SettingsWindow.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the pop-up used to navigate the general settings of the admin.
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Admin
{
    /// 
    /// \class Settings
    ///
    /// \brief This class is responsible for the code behind of the window used to navigate the general settings
    ///
    public partial class SettingsWindow : Window
    {
        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public SettingsWindow()
        {
            InitializeComponent();
        }

        ///
        /// \brief This method is the event handler for the change log directory click. It displays the dialog box
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void ChangeLogDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            LogDirectoryPopUp logDirectoryPopUp = new LogDirectoryPopUp();
            logDirectoryPopUp.ShowDialog();
        }

        ///
        /// \brief This method is the event handler for the change connection info button click. It displays the dialog box
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void ChangeConnectionInfoButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsPopUp connectionSettingsPopUp = new ConnectionSettingsPopUp();
            connectionSettingsPopUp.ShowDialog();
        }

        ///
        /// \brief This method is the event handler for the main menu button click.  It goes back to the main page
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow AdminWindow = new AdminWindow();
            this.Close();
            AdminWindow.Show();
        }

    }
}
