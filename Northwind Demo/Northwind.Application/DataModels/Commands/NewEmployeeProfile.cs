using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Application.DataModels.Commands
{
    public class NewEmployeeProfile
    {
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Extension { get; set; }
        public string FirstName { get; set; }
        public string HomePhone { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public string PostalCode { get; set; }
        public byte[] RawPhoto { get; set; }
        public string Region { get; set; }
        public DateTime? StartDate { get; set; }
        public int Supervisor { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
    }
}
