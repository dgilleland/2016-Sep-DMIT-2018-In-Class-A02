using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application.DataModels
{
    public class ShipDetails
    {
        public ShipDetails()
        {
            
        }
        public object ShippedOn { get; set; }
        public object Shipper { get; set; }
        public ShipAddress ShipTo { get; set; }
    }
}
