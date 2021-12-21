/********************************************//**
 *  Filename: AlterRateFeeTable.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the alter rate fee table window
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

namespace TMS.Pages.Admin
{
    /// 
    /// \class AlterRateFeeTableWindow
    ///
    /// \brief This class is responsible for the code behind of the Alter Rate window
    ///
    public partial class AlterRateFeeTableWindow : Window
    {
        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public AlterRateFeeTableWindow()
        {
            InitializeComponent();
        }

        ///
        /// \brief This method is the button click event handler which opens the insertion dialog
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void RTInsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertRatePopUp insertRatePopUp = new InsertRatePopUp();
            insertRatePopUp.ShowDialog();
        }

        ///
        /// \brief This method is the button click event handler which deletes an entry from the table
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void RTDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRatePopUp deleteRatePopUp = new DeleteRatePopUp();
            deleteRatePopUp.ShowDialog();
        }
    }
}
