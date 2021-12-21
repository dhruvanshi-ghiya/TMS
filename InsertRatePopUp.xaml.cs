/********************************************//**
 *  Filename: InsertRatePopUp.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: December 5
 *	Description: Contains the code behind logic for the pop up used to insert to the Rates database
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
    /// \class InsertRatePopUp
    ///
    /// \brief This class is responsible for the code behind of the Insert Rate pop up window.
    ///        It inserts to the rates table.
    ///
    public partial class InsertRatePopUp : Window
    {
        public TMS.Communications.DataController dataController { get; set; }

        ///
        /// \brief This method initializes the components of the window
        ///
        /// \return Nothing is returned
        ///
        public InsertRatePopUp()
        {
            InitializeComponent();
            dataController = new TMS.Communications.DataController();
        }

        ///
        /// \brief This method inserts to the rates database
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void InsertRateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ftla = Int32.Parse(ftlaTextBox.Text);
                int ltla = Int32.Parse(ltlaTextBox.Text);
                double ftlRate = Double.Parse(ftlRateTextBox.Text);
                double ltlRate = Double.Parse(ltlRateTextBox.Text);
                double reefCharge = Double.Parse(reefChargeTextBox.Text);

                string valuesString = "'" + ClientNameTextBox.Text + "', '" + dCityTextBox.Text + "', '" + ftla + "', '" + ltla + "', '" + ftlRate + "', '" + ltlRate + "', '" + reefCharge + "'";
                string tableName = "Rates";
                dataController.Insert(tableName, valuesString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        ///
        /// \brief This method simply closes the window
        ///
        /// \param object sender
        /// \param RoutedEventArgs e
        /// 
        /// \return Nothing is returned
        ///
        private void CancelRateButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
