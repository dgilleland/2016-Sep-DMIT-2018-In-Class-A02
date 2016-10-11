using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application.DataModels
{
    public class Customer
    {
        public Customer()
        {

        }
        public object CompanyName { get; set; }
        public object ContactName { get; set; }
        public object ContactTitle { get; set; }
        public object Address { get; set; }
        public object City { get; set; }
        public object Region { get; set; }
        public object Country { get; set; }
    }
}
