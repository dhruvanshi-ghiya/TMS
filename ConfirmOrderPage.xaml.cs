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
using TMS.Logic;

namespace TMS.Pages.Planner
{
    /// <summary>
    /// Interaction logic for ConfirmOrderPage.xaml
    /// </summary>
    public partial class ConfirmOrderPage : Window
    {
        Order CurrentOrder;
        private string[] citiesEastToWest = new string[8] { "Ottawa", "Kingston", "Belleville", "Oshawa", "Toronto", "Hamilton", "London", "Windsor" };
        private string[] citiesWestToEast = new string[8] { "Windsor", "London", "Hamilton", "Toronto", "Oshawa", "Belleville", "Kingston", "Ottawa" };
        private string OrderDirection { get; set; }
        private List<Trip> Trips = new List<Trip>();
        private string[] OrderEastboundCities = new string[] { };
        private string[] OrderWestboundCities = new string[] { };

        public ConfirmOrderPage(Order orderToConfirm)
        {
            InitializeComponent();
            CurrentOrder = orderToConfirm;

            DisplayOrderInfo();
            DisplayRoute();
            FillCarrierDropdown();
        }

        private void DisplayOrderInfo()
        {

            string loadType = CurrentOrder.Job_Type == 1 ? "LTL" : "FTL";
            string vanType = CurrentOrder.Van_Type == 1 ? "Reefer" : "Dry";

            string orderInfo = CurrentOrder.ClientName + ": " + vanType + " Van, " + loadType + ", " + "Quantity: " + CurrentOrder.Quantity.ToString();

            OrderInfoSecondary.Text = orderInfo;
        }

        private void DisplayRoute()
        {
            // determine direction of trip (eastbound to westbound)
            // check the location of the start and end city in the corridor to determine direction
            if (Array.IndexOf(citiesEastToWest, CurrentOrder.Origin) > Array.IndexOf(citiesEastToWest, CurrentOrder.Destination))
            {
                OrderDirection = "Eastbound";
            }
            else
            {
                OrderDirection = "Westbound";
            }

            // build the route visual string
            string route = "";

            if (OrderDirection == "Westbound")
            {
                int startIndex = Array.IndexOf(citiesEastToWest, CurrentOrder.Origin);
                int endIndex = Array.IndexOf(citiesEastToWest, CurrentOrder.Destination);

                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (i < endIndex) route += citiesEastToWest[i] + " ---> ";
                    else route += citiesEastToWest[i];

                    OrderWestboundCities.Append(citiesEastToWest[i]);
                }
            }
            else if (OrderDirection == "Eastbound")
            {
                int startIndex = Array.IndexOf(citiesWestToEast, CurrentOrder.Origin);
                int endIndex = Array.IndexOf(citiesWestToEast, CurrentOrder.Destination);

                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (i < endIndex) route += citiesWestToEast[i] + " ---> ";
                    else route += citiesWestToEast[i];

                    OrderEastboundCities.Append(citiesWestToEast[i]);
                }
            }

            RouteVisual.Text = route;
        }

        private void FillCarrierDropdown()
        {
            CarrierDropdown.Items.Add("Planet Express");
            CarrierDropdown.Items.Add("Schooner's");
            CarrierDropdown.Items.Add("Tillman Transport");
            CarrierDropdown.Items.Add("We Haul");
        }

        private void ConfirmOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            // let's add the new active order to the Active Orders list after adding the trips
            // to it. Also update the completion date
            CurrentOrder.Trips = Trips;
            CurrentOrder.DateTimeActivated = PlannerWindow.timer;
            CurrentOrder.SetCompletionDateTime();
            string completionDate = CurrentOrder.CompletionDateTime.ToString("yyyy-MM-dd hh:mm:ss");


            // update order active status and completion date in database
            DataController dc = new DataController();
            dc.Update("Orders", "Active", "1", "OrderID", "'" + CurrentOrder.OrderID + "'");
            dc.Update("Orders", "CompletionDate", "'" + completionDate + "'", "OrderID", "'" + CurrentOrder.OrderID + "'");

            // close window
            this.Close();
        }

        private void AddTripBtn_Click(object sender, RoutedEventArgs e)
        {
            string carrier = CarrierDropdown.SelectedItem.ToString();
            string startCity = StartCityDropdown.SelectedItem.ToString();
            string endCity = EndCityDropdown.SelectedItem.ToString();

            // validate entired
            if (ValidateTripInput(startCity, endCity) == true)
            {
                BuildTrip(carrier, startCity, endCity);
                TripInputError.Text = "";
            }
            else
            {
                TripInputError.Text = "All trips must be going in the " + OrderDirection + " direction.";
                return;
            }
        }

        private bool ValidateTripInput(string startCity, string endCity)
        {
            // validate proper direction
            if (OrderDirection == "Eastbound")
            {
                if (Array.IndexOf(citiesWestToEast, startCity) < Array.IndexOf(citiesWestToEast, endCity))
                {
                    return true;
                }
            }
            else if (OrderDirection == "Westbound")
            {
                if (Array.IndexOf(citiesEastToWest, startCity) < Array.IndexOf(citiesEastToWest, endCity))
                {
                    return true;
                }
            }

            return false;
        }

        private void CarrierDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // first clear the city dropdown to avoid stacking
            StartCityDropdown.Items.Clear();
            EndCityDropdown.Items.Clear();

            // populate the start and end cities with the cities that belong to the selected carrier
            string selectedCarrier = CarrierDropdown.SelectedItem.ToString();

            if (selectedCarrier == "Planet Express")
            {
                foreach (string city in CarrierCities.PlanetExpress)
                {
                    StartCityDropdown.Items.Add(city);
                    EndCityDropdown.Items.Add(city);
                }
            }
            else if (selectedCarrier == "Schooner's")
            {
                foreach (string city in CarrierCities.Schooners)
                {
                    StartCityDropdown.Items.Add(city);
                    EndCityDropdown.Items.Add(city);
                }
            }
            else if (selectedCarrier == "Tillman Transport")
            {
                foreach (string city in CarrierCities.TillmanTransport)
                {
                    StartCityDropdown.Items.Add(city);
                    EndCityDropdown.Items.Add(city);
                }
            }
            else if (selectedCarrier == "We Haul")
            {
                foreach (string city in CarrierCities.WeHaul)
                {
                    StartCityDropdown.Items.Add(city);
                    EndCityDropdown.Items.Add(city);
                }
            }
        }

        private void BuildTrip(string carrierName, string startCity, string endCity)
        {
            Trip trip = new Trip(startCity, endCity, carrierName, CurrentOrder.Job_Type, CurrentOrder.Quantity, CurrentOrder.Van_Type, OrderDirection);
            Trips.Add(trip);
            OrderSummaryList.Items.Add(carrierName + ": " + startCity + " to " + endCity + ". " + OrderDirection);
        }

        private void OrderSummaryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderSummaryList.Items.Remove(OrderSummaryList.SelectedItem);
        }
    }
}
