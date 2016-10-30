using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.DataModels.Commands
{
    public class TerritoryAssignment
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
