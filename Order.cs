/********************************************//**
 *  Filename: Order.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the Order class
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Communications;
using TMS.Pages;

namespace TMS.Logic
{
    /// 
    /// \class Order
    ///
    /// \brief The Order class is basically a collection of 1 or more Trips. This class will be responsible for calculating 
    ///        the total cost of an order, and generating and invoice for the order. The calculations here will be less involved
    ///        since the heavy lifting of calculation is handled by the Trip class. Here, we just add those values together to get
    ///        totals. 
    ///
    public class Order
    {

        public List<Trip> Trips = new List<Trip>(); // where we will store the individual trips that make up an order
        public int Active { get; set; } // 0 = in progress, 1 = active, 2 = complete
        public string ClientName { get; set; }
        public int Job_Type { get; set; }
        public int Quantity { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Van_Type { get; set; }
        public string OrderID { get; set; }
        public DateTime DateTimeActivated { get; set; }
        public DateTime CompletionDateTime { get; set; }

        ///
        /// \brief This constructor takes the order info that was obtained from the CMP and populates the fields
        ///
        /// \param origin - the origin city of the trip
        /// \param destination - the destination city of the trip
        /// \param client - the name of the client that is requesting this order be fulfilled
        /// \param jobType - 0 = FTL, 1 = LTL
        /// \param quantity - 0 = FTL, >0 = # of LTL pallets being moved
        /// \param vanType - 0 = Dry Van; 1 = Reefer Van
        ///
        /// \return Nothing is returned
        ///
        public Order(string id, string origin, string destination, string client,
            int jobType, int quantity, int vanType, int status)
        {
            OrderID = id;
            Origin = origin;
            Destination = destination;
            ClientName = client;
            Job_Type = jobType;
            Quantity = quantity;
            Van_Type = vanType;
            Active = status;
        }

        ///
        /// \brief Adds a trip to the order by appending it to the List<Trip> above
        /// 
        /// \param trip -- a Trip object
        ///
        public void AddTripToOrder(Trip trip)
        {
            Trips.Add(trip);
        }
        ///
        /// \brief Changes the status of the order to "complete", and performs whatever actions are necessary upon the
        ///        completion of an order. 
        ///
        public void MarkAsComplete()
        {
            // only if Trips.Length > 0
            Active = 2;
        }

        ///
        /// \brief Adds a order to the order list 
        /// 
        /// \param newOrder -- a Order object
        ///
        public void AddAOrder(Order newOrder)
        {
            DataController dc = new DataController();
            string values = String.Format("'{0}', '{1}', '{2}', '{3}', {4}, {5}, {6}, {7}",
                                newOrder.OrderID, newOrder.Origin, newOrder.Destination, newOrder.ClientName, newOrder.Job_Type, newOrder.Quantity, newOrder.Van_Type, newOrder.Active);
            dc.Insert("Orders", values);
        }


        ///
        /// \brief This function gathers the cost information from each of the Trips in the Trips list and 
        ///        calculates the final cost of the Order
        ///        
        /// \param a list of trips
        ///
        /// \return Nothing is returned
        ///
        public double CalculateTotalCost()
        {
            double totalCostOfOrder = 0;

            foreach (Trip trip in Trips)
            {
                totalCostOfOrder += trip.GetCost();
            }

            // add on any surcharge
            totalCostOfOrder += CalculateSurcharge();

            return totalCostOfOrder;
        }

        private int CalculateTotalDaysToComplete()
        {
            // get the total number of hours a trip was spent not driving
            int totalRestHours = 0;
            int daysToCompleteOrder = 0;

            foreach (Trip trip in Trips)
            {
                totalRestHours += trip.LoadingTime;
            }

            double totalDrivingHours = CalculateTotalTime() - totalRestHours;

            // a single day will be considered as when either 8 hours of driving or 12 hours total
            // (with <8 hours driving) is reached. Whichever comes first. This is calculated differently
            // for FTL and LTL trips 
            if (Job_Type == 0)
            {
                // total loading time will always be 4 hours
                if (totalDrivingHours <= 8) daysToCompleteOrder = 1;
                if (totalDrivingHours > 8 && totalDrivingHours <= 16) daysToCompleteOrder = 2;
                if (totalDrivingHours > 16 && totalDrivingHours <= 24) daysToCompleteOrder = 3;
                if (totalDrivingHours > 24 && totalDrivingHours <= 32) daysToCompleteOrder = 4;
            }
            else if (Job_Type == 1)
            {
                // loading time will start with 2h, +2h for every 1.75h of driving time (the average
                // length of time to go from one city to another). This makes this calculation a little
                // rough, but good enough. 

                // so a simple way to get the total number of days would be the total trip time / 12,
                // since a driver will always reach 12hr total before 8hr of driving (2hr stops are almost
                // always longer than trips between cities)

                daysToCompleteOrder = (int)(CalculateTotalTime() / 12);
            }


            return daysToCompleteOrder;
        }

        ///
        /// \brief Calculates the total amount of money in surcharches. First it checks how many surcharchn/aes the trip
        ///        requires, and then multiplies that number by 150 to get the dollar value.
        ///
        /// \return an int representing the total cost of the trip
        ///
        private int CalculateSurcharge()
        {
            // a surcharge of $150 is applied for every day after the first. Since a driver can only
            // drive for a max of 8 hours a day, and has 4 hours of rest, we cna figure out how many
            // days a trip will take, assuming a driver is using all 12 hours.


            // calculate how many days past 1 the order took.
            return 150 * CalculateTotalDaysToComplete();
        }

        public double CalculateTotalTime()
        {
            // get the total time taken for all trips in the order
            double totalTime = 0;
            foreach (Trip trip in Trips)
            {
                totalTime += trip.GetTripTime();
            }

            return totalTime;
        }

        public void SetCompletionDateTime()
        {
            DateTime currentDateTime = PlannerWindow.timer;
            int hoursForOrder = (int)(CalculateTotalTime());
            CompletionDateTime = currentDateTime.AddHours(hoursForOrder);
        }


        ///
        /// \brief Takes the newly created order, and adds the relevant information to the Orders table in the database.
        ///        This table is used to render the list of Order in progress as well as Completed Orders. 
        ///
        /// \return Nothing is returned
        ///
        public void AddOrderToDatabase()
        {
            DataController dc = new DataController();
            string values = String.Format("'{0}', '{1}', '{2}', '{3}', {4}, {5}, {6}, {7}, '0000-00-00 00:00:00'",
                                            OrderID, Origin, Destination, ClientName, Job_Type, Quantity, Van_Type, Active);
            dc.Insert("Orders", values);
        }
    }
}
