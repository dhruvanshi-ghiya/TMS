/********************************************//**
 *  Filename: Tri.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the Trip class
 ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Logic
{
    /// 
    /// \class Trip
    ///
    /// \brief This Trip class will hold all the relevant information for any Trips that are part of the route planning system.
    ///        This is also where a lot of the calculation logic will occur for getting the total time of the trip, the km's, and
    ///        the cost. 
    ///
    public class Trip
    {
        private const int MaxOperationTime = 12;
        private const int MaxDrivingTime = 8;
        private string[] citiesEastToWest = new string[8] { "Ottawa", "Kingston", "Belleville", "Oshawa", "Toronto", "Hamilton", "London", "Windsor" };
        private string[] citiesWestToEast = new string[8] { "Windsor", "London", "Hamilton", "Toronto", "Oshawa", "Belleville", "Kingston", "Ottawa" };
        private string Direction { get; set; }
        private int[] EastboundDistances = new int[7] { 191, 128, 68, 60, 134, 82, 196 };
        private int[] WestboundDistances = new int[7] { 196, 82, 134, 60, 68, 128, 191 };
        private double[] EastboundTimes = new double[7] { 2.5, 1.75, 1.25, 1.3, 1.65, 1.2, 2.5 };
        private double[] WestboundTimes = new double[7] { 2.5, 1.2, 1.65, 1.3, 1.25, 1.75, 2.5 };

        private double TotalTime { get; set; }
        private int TotalKM { get; set; }

        public int Surcharge { get; set; }
        public string StartCity { get; set; }
        public string EndCity { get; set; }
        public string Carrier { get; set; }
        public float Cost { get; set; }
        public int LoadType { get; set; }
        public int Quantity { get; set; }
        public int VanType { get; set; }
        public int LoadingTime { get; set; } // mostly for LTL trips. Used to calculate time the order took to complete

        ///
        /// \brief This constructor sets up the basic information for a trip by assigning the parameter values to the class'
        ///        private data members. These values will be used when calculating the time and km and cost. It should
        ///        perform all the calculations automatically upon instantiating the Trip. Then the info can just be pulled
        ///        from it whereever it's needed.
        ///
        /// \param startCity - the origin city of the trip
        /// \param endCity - the destination city of the trip
        /// \param carrier - the carrier responsibile for fulfilling this trip
        /// \param loadType - 0 = FTL, 1 = LTL
        /// \param quantity - 0 = FTL, >0 = # of LTL pallets being moved
        ///
        /// \return Nothing is returned
        ///
        public Trip(string startCity, string endCity, string carrier, int loadType, int quantity, int vanType, string direction)
        {
            StartCity = startCity;
            EndCity = endCity;
            Carrier = carrier;
            LoadType = loadType;
            Quantity = quantity;
            VanType = vanType;
            Direction = direction;
        }

        ///
        /// \brief Calculates the total time of the trip, given the start and end city, as well as the load type.
        ///
        /// \return a float representing the total time in hours
        ///
        public double GetTripTime()
        {
            // to determine the total time of the trip, we use the appropriate eastbound or westbound times array, 
            // and then the total time will be all of the doubles in the array from the index at the originCity until
            // the index at the destination city - 1. 

            double totalTime = 0;

            if (Direction == "Eastbound")
            {
                int startIndex = Array.IndexOf(citiesWestToEast, StartCity);
                int endIndex = Array.IndexOf(citiesWestToEast, EndCity);

                for (int i = startIndex; i < endIndex; i++)
                {
                    totalTime += EastboundTimes[i];
                }
            }
            else if (Direction == "Westbound")
            {
                int startIndex = Array.IndexOf(citiesEastToWest, StartCity);
                int endIndex = Array.IndexOf(citiesEastToWest, EndCity);

                for (int i = startIndex; i < endIndex; i++)
                {
                    totalTime += WestboundTimes[i];
                }
            }

            // calculate any inbetween stops
            if (LoadType == 0) // FTL
            {
                // add 2 hours at the start and end for load in and unload
                totalTime += 4;
                LoadingTime = 4;
            }
            else if (LoadType == 1) // LTL
            {
                // add the 4 hours for load in and unload, + also 2 hours for every intermediary city
                totalTime += 4;

                // how many intermediary cities?
                int intermediaryCities = GetNumberOfInbetweenCities();
                totalTime += intermediaryCities * 2;

                LoadingTime = 4 * (intermediaryCities * 2);
            }

            TotalTime = totalTime;
            return totalTime;
        }

        ///
        /// \brief Calculates the total km of the trip, given the start and end city.
        ///
        /// \return an int representing the total km of the trip
        ///
        public int GetTripKM()
        {
            // to determine the total km of the trip, we use the appropriate eastbound or westbound distances array, 
            // and then the total distance will be all of the ints in the array from the index at the originCity until
            // the index at the destination city - 1. 

            int totalKM = 0;

            if (Direction == "Eastbound")
            {
                int startIndex = Array.IndexOf(citiesWestToEast, StartCity);
                int endIndex = Array.IndexOf(citiesWestToEast, EndCity);

                for (int i = startIndex; i < endIndex; i++)
                {
                    totalKM += EastboundDistances[i];
                }
            }
            else if (Direction == "Westbound")
            {
                int startIndex = Array.IndexOf(citiesEastToWest, StartCity);
                int endIndex = Array.IndexOf(citiesEastToWest, EndCity);

                for (int i = startIndex; i < endIndex; i++)
                {
                    totalKM += WestboundDistances[i];
                }
            }

            TotalKM = totalKM;
            return totalKM;
        }

        public int GetNumberOfInbetweenCities()
        {

            int intermediaryCities = 0;

            if (Direction == "Eastbound")
            {
                int startIndex = Array.IndexOf(citiesWestToEast, StartCity);
                int endIndex = Array.IndexOf(citiesWestToEast, EndCity);
                intermediaryCities = endIndex - startIndex - 1;
            }
            else if (Direction == "Westbound")
            {
                int startIndex = Array.IndexOf(citiesEastToWest, StartCity);
                int endIndex = Array.IndexOf(citiesEastToWest, EndCity);
                intermediaryCities = endIndex - startIndex - 1;
            }

            return intermediaryCities;
        }

        ///
        /// \brief Calculates the total cost of the trip.
        ///
        /// \return a float representing the total cost of the trip
        ///
        public double GetCost()
        {
            double finalCost = 0;
            double FTLRate = 0;
            double LTLRate = 0;

            // get rates based on carrier
            CarrierRates cr = new CarrierRates();
            FTLRate = cr.GetFTLRate(Carrier);
            LTLRate = cr.GetLTLRate(Carrier);


            // if this trip is using a reefer van, apply the reefer charge to the rates above
            if (VanType == 1)
            {
                FTLRate += FTLRate * cr.GetReefCharge(Carrier);
                LTLRate += LTLRate * cr.GetReefCharge(Carrier);
            }

            // apply the OSHT markup on FTL and LTL rates
            FTLRate += FTLRate * 0.08; // 8% increase on FTL rate
            LTLRate += LTLRate * 0.05; // 5% increase on LTL rate

            // determine the cost of the total KM depending on the load type
            if (LoadType == 0) // FTL
            {
                finalCost += TotalKM * FTLRate;
            }
            else if (LoadType == 1) // LTL
            {
                finalCost += (TotalKM * LTLRate) * Quantity;
            }

            return finalCost;
        }
    }
}
