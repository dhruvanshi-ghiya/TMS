/********************************************//**
 *  Filename: LogDirectoryPopUp.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the pop-up used to change the log directory
 ***********************************************/

using System;
using System.IO;
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
using System.Configuration;

namespace Admin
{
    /// 
    /// \class LogDirectoryPopUp
    ///
    /// \brief This class is responsible for the code behind of the pop-up used to change the log directory
    ///
    public partial class LogDirectoryPopUp : Window
    {
        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public LogDirectoryPopUp()
        {
            InitializeComponent();
            LogFileDirectoryTextBox.Text = ConfigurationManager.AppSettings["logFilePath"];
        }

        ///
        /// \brief This method is the event handler for the Ok directory pop-up button.
        ///        It validates the user inputted directory and if it is valid changes the
        ///        log file directory and move the file
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void OkDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(LogFileDirectoryTextBox.Text))
            {
                MessageBox.Show("The directory you have entered does not exist!");
            }
            else
            {
                
                string logPath = ConfigurationManager.AppSettings["logFilePath"] + "TMSLog.log";
                ConfigurationManager.AppSettings["logFilePath"] = LogFileDirectoryTextBox.Text;

                //Copy Log File to New Location
                try 
                {
                    File.Move(logPath, ConfigurationManager.AppSettings["logFilePath"]);
                } 
                catch (Exception) 
                {
                    MessageBox.Show("The file could not be moved!");
                }
                
            }
        }

        ///
        /// \brief This method simply closes the popup window if the user wishes to exit
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void CancelDirectory_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
