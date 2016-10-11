using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application.DataModels
{
    public class ShipAddress
    {
        public ShipAddress()
        {
            
        }
        public object CareOf { get; set; }
        public object Address { get; set; }
        public object City { get; set; }
        public object Region { get; set; }
        public object Country { get; set; }
    }
}
