/********************************************//**
 *  Filename: AdminWindow.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for first screen that the admin will see when they login.
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Pages;

namespace Admin
{
    /// 
    /// \class Settings
    ///
    /// \brief This class is responsible for the code behind of the window used to navigate all options available to admin
    ///
    public partial class AdminWindow : Window
    {
        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public AdminWindow()
        {
            InitializeComponent();
        }

        ///
        /// \brief This method is the event handler for the settings button click - it goes to the settings window.
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            this.Close();
            settingsWindow.Show();
        }

        ///
        /// \brief This method is the event handler for the review log files button click - it goes to that window.
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void ReviewLogfilesButton_Click(object sender, RoutedEventArgs e)
        {
            ReviewLogWindow reviewLogWindow = new ReviewLogWindow();
            this.Close();
            reviewLogWindow.Show();
        }

        ///
        /// \brief This method is the event handler for the alter log files button click - it goes to that window.
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void AlterRateFeeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        ///
        /// \brief This method is the event handler for the alter carrier data button click - it goes to that window.
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void AlterCarrierData_Click(object sender, RoutedEventArgs e)
        {

        }

        ///
        /// \brief This method is the event handler for the alter route table button click - it goes to that window.
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void AlterRouteTable_Click(object sender, RoutedEventArgs e)
        {

        }

        ///
        /// \brief This method is the event handler for the backup database button click - it opens that popup.
        ///
        /// \return Nothing is returned
        ///
        private void BackupDatabase_Click(object sender, RoutedEventArgs e)
        {
            BackupDatabasePopUp backupDatabasePopUp = new BackupDatabasePopUp();
            backupDatabasePopUp.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignIn s = new SignIn();
            s.Show();
            this.Close();
        }
    }
}
