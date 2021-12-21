/********************************************//**
 *  Filename: PlannerWindow.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the PlannerWindow page
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
using System.Windows.Threading;
using TMS.Communications;
using TMS.Logic;
using TMS.Logic.Orders;
using TMS.Pages.Planner;

namespace TMS.Pages
{
    /// <summary>
    /// Interaction logic for PlannerWindow.xaml
    /// </summary>
    public partial class PlannerWindow : Window
    {
        public static List<Trip> tmpTrips = new List<Trip>();
        private int dayIncrement = 0;
        public static DateTime timer { get; set; }

        public PlannerWindow()
        {
            // start timer
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

            InitializeComponent();

            PopulateActiveOrders();
            PopulatePendingOrders();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime displayDateTime = currentDateTime.AddHours(dayIncrement);
            timer = displayDateTime;
            LiveTimeLabel.Content = timer.ToString("MMMM dd, HH:mm:ss");

            // every second were going to check the active orders to see if any are complete. If they are, 
            // we will update their status to "complete" (3). This should allow the lists to update every second.

            DataController dc = new DataController();
            List<Order> orders = dc.RetrieveOrders(1);

            foreach (Order o in orders)
            {
                DateTime dt = dc.GetOrderCompletionDate(o.OrderID);
                if (dt <= timer)
                {
                    dc.Update("Orders", "Active", "2", "OrderID", "'" + o.OrderID + "'");
                }
            }
        }

        ///
        /// \brief This method will contain the logic for incrementing the date by 1 day. This date variable will have to be pretty global
        ///        and will have to update any orders that depend on it to track their progress. 
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        ///
        private void AddOneDay_Click(object sender, RoutedEventArgs e)
        {
            dayIncrement += 1;
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            SignIn s = new SignIn();
            s.Show();
            this.Close();
        }

        ///
        /// \brief This method will prompt the user to select the type of summary report they want (all time or the last 2 weeks)
        ///        and depending on the choice, will generate the summary report which will then be stored in the database (Invoice
        ///        table). public
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        ///
        private void Generate_Summary_Report(object sender, RoutedEventArgs e)
        {
            SummaryReport SR = new SummaryReport();
            SR.Show();
        }

        // grab the active orders and display them
        private void btn_ActiveOrdersRefreshClick(object sender, RoutedEventArgs e)
        {
            PopulateActiveOrders();
        }

        private void PopulateActiveOrders()
        {
            // first, clear the list before refreshing
            ActiveOrdersListBox.Items.Clear();

            DataController dc = new DataController();

            // add each order to the list box
            List<Order> activeOrders = dc.RetrieveOrders(1);
            foreach (Order o in activeOrders)
            {
                string jobType = o.Job_Type == 0 ? "FTL" : "LTL";
                DateTime dt = dc.GetOrderCompletionDate(o.OrderID);
                ActiveOrdersListBox.Items.Add(o.ClientName + " -- " + o.Origin + " to " + o.Destination + " (" + jobType + ")" + "        Due: " + dt.ToString("MMM dd @ HH: mm"));

                ActiveOrders.Add(o);
            }
        }

        // show all pending order that came from the buyer
        private void btn_PendingOrdersRefreshCick(object sender, RoutedEventArgs e)
        {
            PopulatePendingOrders();
        }

        private void PopulatePendingOrders()
        {
            // first, clear the list before refreshing
            PendingOrdersListBox.Items.Clear();

            DataController dc = new DataController();

            // add each order to the list box
            List<Order> pendingOrders = dc.RetrieveOrders(0);
            foreach (Order o in pendingOrders)
            {
                string jobType = o.Job_Type == 0 ? "FTL" : "LTL";
                PendingOrdersListBox.Items.Add(o.ClientName + " -- " + o.Origin + " to " + o.Destination + " (" + jobType + ") ");

                PendingOrders.Add(o);
            }
        }

        private void ActiveOrdersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // construct an information string showing all of the order info
            int index = ActiveOrdersListBox.SelectedIndex;
            try
            {
                Order currentOrder = ActiveOrders.GetAll()[index];
                List<Trip> currentOrderTrips = currentOrder.Trips;
                string loadType = currentOrder.Job_Type == 1 ? "LTL" : "FTL";
                string vanType = currentOrder.Van_Type == 1 ? "Reefer" : "Dry";

                string orderInfo = "Order ID: " + currentOrder.OrderID + "\n" +
                                   "Client: " + currentOrder.ClientName + "\n" +
                                   "Origin: " + currentOrder.Origin + "\n" +
                                   "Destination: " + currentOrder.Destination + "\n" +
                                   "Van Type: " + vanType + "\n" +
                                   "Load Type: " + loadType + "\n" +
                                   "Quantity: " + currentOrder.Quantity.ToString() + "\n\n" +
                                   "TRIP(S):" + "\n";

                // add trip info to the summary
                foreach (Trip trip in currentOrderTrips)
                {
                    orderInfo += " -- " + trip.Carrier + " from " + trip.StartCity + " to " + trip.EndCity;
                }

                MessageBox.Show(orderInfo);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void PendingOrdersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = PendingOrdersListBox.SelectedIndex;
            Order currentOrder = index == -1 ? null : PendingOrders.GetAll()[index];

            // open confirm order window
            ConfirmOrderPage confirmOrderWindow = new ConfirmOrderPage(currentOrder);
            confirmOrderWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CMPConnector con = new CMPConnector();

            // get all active contracts from the db and fill a list
            List<Contract> showContracts = new List<Contract>();
            showContracts = con.GetContracts();

            // add each Contract to the information list box
            foreach (Contract c in showContracts)
            {
                // create a unique Order ID with guid; manually set active status to 0
                Guid id = Guid.NewGuid();

                Order o = new Order(id.ToString(), c.Origin, c.Destination, c.ClientName, c.Job_Type, c.Quantity, c.Van_Type, 0);
                o.AddOrderToDatabase();
            }
        }
    }
}
