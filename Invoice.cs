using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Logic
{
    public class Invoice
    {
        public string OrderID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Client { get; set; }
        public int JobType { get; set; }
        public int Quantity { get; set; }
        public int VanType { get; set; }
        public DateTime CompletionDate { get; set; }
        public int DaysToComplete { get; set; }
        public double TotalCost { get; set; }
        public int TotalKM { get; set; }
        public double TotalTime { get; set; }
        public int Surcharge { get; set; }

        public Invoice(string id, string origin, string destination, string client,
          int jobType, int quantity, int vanType, DateTime completionDate, int daysToComplete,
           double totalCost, int totalKM, double totalTime, int surcharge)
        {
            OrderID = id;
            Origin = origin;
            Destination = destination;
            Client = client;
            JobType = jobType;
            Quantity = quantity;
            VanType = vanType;
            CompletionDate = completionDate;
            DaysToComplete = daysToComplete;
            TotalCost = totalCost;
            TotalKM = totalKM;
            TotalTime = totalTime;
            Surcharge = surcharge;
        }
    }
}
