/********************************************//**
 *  Filename: DeleteRatePopUp.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the pop up used to delete from the Rates database
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
using TMS.Communications;

namespace TMS.Pages.Admin
{
    /// 
    /// \class DeleteRatePopUp
    ///
    /// \brief This class is responsible for the code behind of the Delete Rate pop up window
    ///
    public partial class DeleteRatePopUp : Window
    {
        public TMS.Communications.DataController dataController { get; set; }

        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public DeleteRatePopUp()
        {
            InitializeComponent();
            dataController = new TMS.Communications.DataController();
        }

        ///
        /// \brief This method deletes an entry based on primary key and value
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void DeleteRate_Click(object sender, RoutedEventArgs e)
        {
            string tableName = "Rates";
            string primaryKey = "ClientName";
            string value = DeleteRateTextBox.Text;
            dataController.Delete(tableName, primaryKey, value);
        }

        ///
        /// \brief This method simply closes the window
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///

        private void CancelRate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
