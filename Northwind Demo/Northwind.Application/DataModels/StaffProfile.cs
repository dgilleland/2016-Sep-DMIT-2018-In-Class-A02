using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.DataModels
{
    public class StaffProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public DateTime? HireDate { get; set; }
        public byte[] Photo { get; set; }
        public IEnumerable<string> Territories { get; set; }
        public byte[] CleanPhoto
        {
            get
            {
                return Photo.Skip(78).ToArray();
            }
        }
    }
}
