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
    /// Interaction logic for SummaryReport.xaml
    /// </summary>
    public partial class SummaryReport : Window
    {
        public SummaryReport()
        {
            InitializeComponent();
            PopulateAllTimeListBox();
            PopulateTwoWeeksListBox();
        }

        private void PopulateAllTimeListBox()
        {
            DataController dc = new DataController();

            // add each order to the list box
            List<Invoice> activeOrders = dc.RetrieveAllInvoices();
            foreach (Invoice i in activeOrders)
            {
                string jobType = i.JobType == 0 ? "FTL" : "LTL";

                string summaryReport = "Order ID: " + i.OrderID + "\n" +
                                   "Client: " + i.Client + "\n" +
                                   "Origin: " + i.Origin + "\n" +
                                   "Destination: " + i.Destination + "\n" +
                                   "Van Type: " + i.VanType + "\n" +
                                   "Load Type: " + jobType + "\n" +
                                   "Quantity: " + i.Quantity.ToString() + "\n" +
                                   "Completion Date: " + i.CompletionDate.ToString("MMM dd") + "\n" +
                                   "Days To Complete: " + i.DaysToComplete.ToString() + "\n" +
                                   "Total Cost: $" + i.TotalCost.ToString() + "\n" +
                                   "Total KM's: " + i.TotalKM.ToString() + "\n" +
                                   "Total Time Taken: " + i.TotalTime.ToString() + "\n" +
                                   "Surcharge: " + i.Surcharge.ToString() + "\n";

                AllTimeListBox.Items.Add(summaryReport);
            }
        }

        private void PopulateTwoWeeksListBox()
        {

        }
    }
}
