using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Logic
{
    class Contract
    {
        public string ClientName { get; set; }
        public int Job_Type { get; set; }
        public int Quantity { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Van_Type { get; set; }

        public Contract(string client, int jobType, int quantity, string origin, string destination, int vanType)
        {
            ClientName = client;
            Job_Type = jobType;
            Quantity = quantity;
            Origin = origin;
            Destination = destination;
            Van_Type = vanType;
        }
    }
}
