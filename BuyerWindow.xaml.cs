/********************************************//**
 *  Filename: BuyerWindow.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the BuyerWindow page
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
using TMS.Communications;
using TMS.Logic;

namespace TMS.Pages
{
    /// 
    /// \class BuyerWindow
    ///
    /// \brief The Buyer Window is where the workflow of the Buyer will take place. Here, they can view available contracts from
    ///        the CMP and initiate those orders by choosing candidate cities. They can also view customers and in that view add
    ///        or delete them. They can also view completed order, which they can finalize by generating an invoice for.
    ///

    public partial class BuyerWindow : Window
    {
        public BuyerWindow()
        {
            InitializeComponent();
        }

        ///
        /// \brief This button click fetches all of the available contracts from the CMP and displays them in the 
        ///        information box. From there, the buyer can select a contract to initiat by selecting cities.
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void ViewContracts_Click(object sender, RoutedEventArgs e)
        {
            // Grab all order requests from CMP
            // create a new Contract to use to grab the active contracts
            CMPConnector con = new CMPConnector();

            // get all active contracts from the db and fill a list
            List<Contract> showContracts = new List<Contract>();
            showContracts = con.GetContracts();

            // add each Contract to the information list box
            foreach (Contract c in showContracts)
            {
                // create a unique Order ID with guid; manually set active status to 0
                Guid id = new Guid();
                Order o = new Order(id.ToString(), c.Origin, c.Destination, c.ClientName, c.Job_Type, c.Quantity, c.Van_Type, 0);
                o.AddOrderToDatabase();
            }
            return;
        }

        ///
        /// \brief This button click fetches all of the available customers from the database and diaplays them in the 
        ///        information box. From there, the buyer can select a customer to modify (add/delete).
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void ViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            // first, clear the list before refreshing
            CustomersListBox.Items.Clear();

            // Grab all contracts from CMP
            // create a new Contract to use to grab the active contracts
            CMPConnector con = new CMPConnector();

            // get all active contracts from the db and fill a list
            List<Contract> showContracts = new List<Contract>();
            showContracts = con.GetContracts();

            // add each Contract to the information list box
            foreach (Contract c in showContracts)
            {
                CustomersListBox.Items.Add(c.ClientName);
            }
        }

        ///
        /// \brief This button click fetches all of the completed orders from the database and diaplays them in the 
        ///        information box. From there, the buyer can select an order to finalize by generating an invoice.
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void ViewCompletedOrders_Click(object sender, RoutedEventArgs e)
        {
            // first, clear the list before refreshing
            CompletedOrderListBox.Items.Clear();

            // add each order to the list box
            DataController dc = new DataController();
            List<Order> completedOrders = dc.RetrieveOrders(2);
            foreach (Order o in completedOrders)
            {
                string jobType = o.Job_Type == 0 ? "FTL" : "LTL";
                CompletedOrderListBox.Items.Add(o.ClientName + " -- " + o.Origin + " to " + o.Destination + " (" + jobType + ")" + "      ");

                CompletedOrders.Add(o);
            }
        }

        ///
        /// \brief Initiates the process of creating a new order (instantiating an Order object with the information from the CMP,
        ///        and selecting the relevant cities)
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            CMPConnector cmp = new CMPConnector();
            cmp.CallOrder();
            return;
        }

        ///
        /// \brief Initiates the process of adding new customer from the CMP (they will be added to the DB Customers table)
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            // Grab all contracts from DC
            // create a new Contract to use to grab the active contracts
            DataController dc = new DataController();

            // add each order to the list box
            List<Order> completedOrders = CompletedOrders.GetAll();

            // add customer to the list box
            foreach (Order o in completedOrders)
            {
                string values = String.Format("'{0}'", o.ClientName);
                CustomersListBox.Items.Add(o.ClientName);
                dc.Insert("Orders", values);
            }
        }

        ///
        /// \brief This event will contain a good amount of logic that is repsonsible for automatically generating an invoice
        ///        for a completed order. All of the imformation needed to generate the invoice should already be present in the
        ///        Order object as well as the database. So it's a matter of grabbing that information, creating a text file, and
        ///        then writing all of the necessasry information to it. 
        ///
        /// \param default button click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void GenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            // create a unique Order ID with guid; manually set active status to 0
            Guid id = new Guid();

            Order completedOrder = new Order("ABC", "1", "1", "XYZ", 1, 1, 1, 1);

            // Create a string with a line of text.
            List<Trip> completedOrderTrips = completedOrder.Trips;
            string loadType = completedOrder.Job_Type == 1 ? "LTL" : "FTL";
            string vanType = completedOrder.Van_Type == 1 ? "Reefer" : "Dry";

            string orderInfo = "Order ID: " + completedOrder.OrderID + "\n" +
                               "Client: " + completedOrder.ClientName + "\n" +
                               "Origin: " + completedOrder.Origin + "\n" +
                               "Destination: " + completedOrder.Destination + "\n" +
                               "Van Type: " + vanType + "\n" +
                               "Load Type: " + loadType + "\n" +
                               "Quantity: " + completedOrder.Quantity.ToString() + "\n\n" +
                               "TRIP(S):" + "\n";

            // add trip info to the summary
            foreach (Trip trip in completedOrderTrips)
            {
                orderInfo += "Client: " + trip.Carrier + "\n" +
                               "Start City: " + trip.StartCity + "\n" +
                               "End City: " + trip.EndCity + "\n" +
                                "Cost: " + trip.Carrier + "\n" +
                               "Total KM: " + trip.StartCity + "\n" +
                               "Total Time: " + trip.EndCity + "\n";
            }

            MessageBox.Show(orderInfo);

            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);  //Edit this later

            // Write the text to a new file named "WriteFile.txt".
            File.WriteAllText(System.IO.Path.Combine(docPath, "Invoice.txt"), orderInfo);
            return;
        }



        private void ContractsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // construct an information string showing all of the order info
            int index = ContractsListBox.SelectedIndex;
            CMPConnector cmp = new CMPConnector();
            cmp.GetContracts();

        }

        private void CustomersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // construct an information string showing all of the order info
            int index = CustomersListBox.SelectedIndex;
            Order currentOrder = CompletedOrders.GetAll()[index];
            List<Trip> currentOrderTrips = currentOrder.Trips;

            string ClientInfo = "Client: " + currentOrder.ClientName + "\n";

            // add trip info to the summary
            foreach (Trip trip in currentOrderTrips)
            {
                ClientInfo += " -- " + trip.Carrier + " from " + trip.StartCity + " to " + trip.EndCity;
            }

            MessageBox.Show(ClientInfo);
        }

        private void CompletedOrderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // construct an information string showing all of the order info
            int index = CompletedOrderListBox.SelectedIndex;
            Order completedOrder = CompletedOrders.GetAll()[index];
            List<Trip> completedOrderTrips = completedOrder.Trips;
            string loadType = completedOrder.Job_Type == 1 ? "LTL" : "FTL";
            string vanType = completedOrder.Van_Type == 1 ? "Reefer" : "Dry";

            string orderInfo = "Order ID: " + completedOrder.OrderID + "\n" +
                               "Client: " + completedOrder.ClientName + "\n" +
                               "Origin: " + completedOrder.Origin + "\n" +
                               "Destination: " + completedOrder.Destination + "\n" +
                               "Van Type: " + vanType + "\n" +
                               "Load Type: " + loadType + "\n" +
                               "Quantity: " + completedOrder.Quantity.ToString() + "\n\n" +
                               "TRIP(S):" + "\n";

            // add trip info to the summary
            foreach (Trip trip in completedOrderTrips)
            {
                orderInfo += " -- " + trip.Carrier + " from " + trip.StartCity + " to " + trip.EndCity;
            }

            MessageBox.Show(orderInfo);
        }

        // SIGN OUT
        // SIGN OUT
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignIn s = new SignIn();
            s.Show();
            this.Close();
        }
    }
}