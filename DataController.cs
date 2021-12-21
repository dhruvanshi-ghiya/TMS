/********************************************//**
 *  Filename: DataController.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the Data controller class
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TMS.Logic;
using System.Configuration;

namespace TMS.Communications
{
    /// 
    /// \class DataController
    ///
    /// \brief The class is reponsible for connecting to, and interacting with the TMS database. It is through this class that
    ///        other classes can retrieve the data they need as well as update or change any data that needs to be updated.
    ///
    public class DataController
    {
        MySqlCommand genericCommand { get; set; }
        string commandString { get; set; }

        MySqlConnection dbConnection { get; set; }
        MySqlDataReader reader { get; set; }
        private const string connectionString = "SERVER=" + "localhost" + ";" + "DATABASE=" +
            "tms" + ";" + "UID=" + "TMSuser" + ";" + "PASSWORD=" + "sq-group-10" + ";" + "convert zero datetime=True" + ";";
        ///
        /// \brief This constructor connects to the TMS database whenever a DataController is instantiated
        ///
        /// \param string connectionString
        /// 
        /// \test Test a faulty connection string
        ///
        /// \return Nothing is returned
        ///
        public DataController()
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

        ///
        /// \brief This function attempts to insert to the database based on provided arguments
        /// 
        /// \param string tableName
        /// \param string tableValues
        /// 
        /// \test Test a nonexistent table
        /// \test Test a nonexistent string
        ///
        /// \return Nothing is returned
        ///
        public void Insert(string tableName, string tableValues)
        {
            //Build string where tableName contains TableName (x, y, z) and table values contains ('x', 'y', 'z')
            commandString = "INSERT INTO " + tableName + " VALUES " + " (" + tableValues + ");";

            //Set up command
            genericCommand = new MySqlCommand(commandString, dbConnection);

            //Execute command
            genericCommand.ExecuteNonQuery();
        }

        ///
        /// \brief This function attempts to update the database based on provided arguments
        /// 
        /// \param string tableName
        /// \param string fieldToChange
        /// \param string newValue
        /// \param string oldValue
        /// \param string primaryKey
        /// 
        /// \test Test a nonexistent table
        /// \test Test with bad values
        ///
        /// \return Nothing is returned
        ///
        public void Update(string tableName, string fieldToChange, string newValue, string primaryKey, string oldValue)
        {
            //Build update string based on arguments
            commandString = "UPDATE " + tableName + " SET " + fieldToChange + "=" + newValue + " " + "WHERE " + primaryKey + "=" + oldValue + ";";

            //Set up command
            genericCommand = new MySqlCommand(commandString, dbConnection);

            //Execute command
            genericCommand.ExecuteNonQuery();
        }

        ///
        /// \brief This function attempts to delete an entry in the database based on provided arguments
        /// 
        /// \param string tableName
        /// \param string primaryKey
        /// \param string value
        /// 
        /// \test Test a nonexistent table
        /// \test Test a nonexistent entry
        ///
        /// \return Nothing is returned
        ///
        public void Delete(string tableName, string primaryKey, string value)
        {
            //Build update string based on arguments
            commandString = "DELETE FROM " + tableName + "WHERE " + primaryKey + "='" + value + "';";

            //Set up command
            genericCommand = new MySqlCommand(commandString, dbConnection);

            //Execute command
            genericCommand.ExecuteNonQuery();

        }

        // get all order data, allowing for specific filtering based on the active status
        public List<Order> RetrieveOrders(int activeStatus)
        {

            List<Order> activeOrders = new List<Order>();

            string query = "SELECT * FROM Orders WHERE Active=" + activeStatus.ToString() + ";";
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

                activeOrders.Add(order);
            }

            reader.Close();
            return activeOrders;
        }


        public DateTime GetOrderCompletionDate(string id)
        {
            string query = "SELECT CompletionDate FROM Orders WHERE OrderID='" + id + "';";
            genericCommand = new MySqlCommand(query, dbConnection);

            reader = genericCommand.ExecuteReader();

            while (reader.Read())
            {
                DateTime dtm = reader.GetDateTime("CompletionDate");
                reader.Close();
                return dtm;
            }

            reader.Close();
            DateTime dt = new DateTime(0000, 00, 00, 00, 00, 00);
            return dt;
        }

        public List<Invoice> RetrieveAllInvoices()
        {

            List<Invoice> allInvoices = new List<Invoice>();

            string query = "SELECT * FROM Invoices;";
            genericCommand = new MySqlCommand(query, dbConnection);

            reader = genericCommand.ExecuteReader();

            while (reader.Read())
            {
                Invoice invoice = new Invoice(
                   reader.GetString("OrderID"),
                   reader.GetString("Origin"),
                   reader.GetString("Destination"),
                   reader.GetString("Client"),
                   reader.GetInt32("JobType"),
                   reader.GetInt32("Quantity"),
                   reader.GetInt32("VanType"),
                   reader.GetDateTime("CompletionDate"),
                   reader.GetInt32("DaysToComplete"),
                   reader.GetDouble("TotalCost"),
                   reader.GetInt32("TotalKM"),
                   reader.GetDouble("TotalTime"),
                   reader.GetInt32("Surcharge")
                );

                allInvoices.Add(invoice);
            }

            reader.Close();
            return allInvoices;
        }

        public string ValidateUser(string user, string pass)
        {
            string query = "SELECT * FROM Users WHERE UserName='" + user + "' AND Password='" + pass + "';";
            genericCommand = new MySqlCommand(query, dbConnection);
            reader = genericCommand.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetString("UserRole");
            }

            return "Not Found";
        }

        ///
        /// \brief This function closes the database connection
        /// 
        /// \return Nothing is returned
        ///
        public void EndConnection()
        {
            //End the connection
            dbConnection.Close();
        }




    }
}
