using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application.DataModels
{
    public class CustomerOrder
    {
        public CustomerOrder()
        {
            
        }
        public object OrderedOn { get; set; }
        public object RequiredBy { get; set; }
        public ShipDetails Shipping { get; set; }
        public object OrderDetails { get; set; }
        public SalesRepresentative SalesRep { get; set; }
    }
}
