/********************************************//**
 *  Filename: CMPConnect.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the CMPConnector class
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TMS.Logic;

namespace TMS.Communications
{
    /// 
    /// \class CMPConnector
    ///
    /// \brief The CMPConnector class is responsible for handling the connection to and interaction with the
    ///        contract marketplace.  This class is currently not fleshed out as we are not sure yet of
    ///        what will be required here.  Additionally, all methods in this class might not be necessary, it may be
    ///        possible to use the DataController class solely.
    ///
    class CMPConnector
    {
        MySqlCommand genericCommand { get; set; }
        string commandString { get; set; }

        MySqlConnection dbConnection { get; set; }
        MySqlDataReader reader { get; set; }
        private const string connectionString = "SERVER=" + "159.89.117.198" + ";" + "DATABASE=" +
            "cmp" + ";" + "UID=" + "DevOSHT" + ";" + "PASSWORD=" + "Snodgr4ss!" + ";";
        private List<Contract> ListOfContracts = new List<Contract>();

        public CMPConnector()
        {
            //Set up connection
            dbConnection = new MySqlConnection(connectionString);

            try
            {
                //Connect
                dbConnection.Open();
            }
            catch (MySqlException e)
            {
                //Display error message
            }
        }

        // Request for a new order
        public void CallOrder()
        {
            Order o = new Order("ABC", "1", "1", "XYZ", 1, 1, 1, 1);
            o.AddAOrder(o);
        }

        // get all order data, allowing for specific filtering based on the in-progress status
        public List<Order> RequestOrder(int inProgressStatus)
        {
            List<Order> newOrders = new List<Order>();
            string query = "SELECT * FROM Orders WHERE Status=" + inProgressStatus.ToString() + ";";
            genericCommand = new MySqlCommand(query, dbConnection);

            reader = genericCommand.ExecuteReader();

            while (reader.Read())
            {
                Order order = new Order(
                   reader.GetString("OrderID"),
                   reader.GetString("Origin"),
                   reader.GetString("Destination"),
                   reader.GetString("Client"),
                   reader.GetInt32("JobType"),
                   reader.GetInt32("Quantity"),
                   reader.GetInt32("VanType"),
                   reader.GetInt32("Active")
                );

                newOrders.Add(order);
            }

            return newOrders;
        }
        public List<Contract> GetContracts()
        {

            string query = "SELECT * FROM Contract;";
            genericCommand = new MySqlCommand(query, dbConnection);

            reader = genericCommand.ExecuteReader();

            while (reader.Read())
            {
                Contract contract = new Contract(
                   reader.GetString("Client_Name"),
                   reader.GetInt32("Job_Type"),
                   reader.GetInt32("Quantity"),
                   reader.GetString("Origin"),
                   reader.GetString("Destination"),
                   reader.GetInt32("Van_Type")
                );

                ListOfContracts.Add(contract);
            }

            return ListOfContracts;
        }
    }
}
