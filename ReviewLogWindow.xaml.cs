/********************************************//**
 *  Filename: ReviewLogWindow.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the window used to view the log file
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
using System.IO;

namespace Admin
{
    /// 
    /// \class ReviewLogWindow
    ///
    /// \brief This class is responsible for the code behind of the window used to view the logfile
    ///
    public partial class ReviewLogWindow : Window
    {
        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public ReviewLogWindow()
        {
            InitializeComponent();
          //  LogFileTextBox.Text = File.ReadAllText(@filepath);
        }

        private void ExitLogButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow AdminWindow = new AdminWindow();
            this.Close();
            AdminWindow.Show();
        }
    }
}
