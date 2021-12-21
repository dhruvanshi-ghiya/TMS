/********************************************//**
 *  Filename: ConnectionSettingsPopUp.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the pop up used to change the connection settings.
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
using System.Net;
using System.Net.NetworkInformation;
using System.Configuration;

namespace Admin
{
    /// 
    /// \class ConnectionSettingsPopUP
    ///
    /// \brief This class is responsible for the code behind of the Connection Settings pop up window.
    ///        It collects a new IP and password and changes those settings.
    ///
    public partial class ConnectionSettingsPopUp : Window
    {
        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public ConnectionSettingsPopUp()
        {
            InitializeComponent();
            IPTextBox.Text = ConfigurationManager.AppSettings["ipaddress"];
            PortTextBox.Text = ConfigurationManager.AppSettings["password"];
        }

        ///
        /// \brief This method is the event handler for the set connection button click.
        ///        It validates the IP address, and sets the new values.
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void SetConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            string ipString = IPTextBox.Text;

            try
            {
                IPAddress address = IPAddress.Parse(ipString);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid IP Address!");
                return;
            }

            //Set new IP
            ConfigurationManager.AppSettings["ipaddress"] = IPTextBox.Text;

            if (PortTextBox.Text == "")
            {
                //Don't change pasword
            }
            else
            {
                ConfigurationManager.AppSettings["password"] = PortTextBox.Text;
            }

            MessageBox.Show("Connection Details Changed Successfully!");
            this.Close();
        }

        ///
        /// \brief This method simply closes the pop up if the user wishes to exit
        /// 
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void CancelConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
