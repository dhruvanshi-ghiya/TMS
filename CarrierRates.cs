using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Logic
{
    class CarrierRates
    {
        public double GetFTLRate(string carrierName)
        {
            if (carrierName == "Planet Express")
            {
                return 5.21;
            }
            else if (carrierName == "Schooner's")
            {
                return 5.05;
            }
            else if (carrierName == "Tillman Transport")
            {
                return 5.11;
            }
            else if (carrierName == "We Haul")
            {
                return 5.2;
            }
            else
            {
                return 0;
            }
        }

        public double GetLTLRate(string carrierName)
        {
            if (carrierName == "Planet Express")
            {
                return 0.3621;
            }
            else if (carrierName == "Schooner's")
            {
                return 0.3434;
            }
            else if (carrierName == "Tillman Transport")
            {
                return 0.3012;
            }
            else if (carrierName == "We Haul")
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public double GetReefCharge(string carrierName)
        {
            if (carrierName == "Planet Express")
            {
                return 0.08;
            }
            else if (carrierName == "Schooner's")
            {
                return 0.07;
            }
            else if (carrierName == "Tillman Transport")
            {
                return 0.09;
            }
            else if (carrierName == "We Haul")
            {
                return 0.065;
            }
            else
            {
                return 0;
            }
        }
    }
}
