using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application.DataModels
{
    public class CustomerOrderDetail
    {
        public CustomerOrderDetail()
        {
            
        }
        public object Item { get; set; }
        public object Unit { get; set; }
        public object OrderQuantity { get; set; }
        public object UnitPrice { get; set; }
        public object Discount { get; set; }
    }
}
