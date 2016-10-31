using Northwind.Application.BLL.Adapters;
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
        public IEnumerable<StaffTerritory> Territories { get; set; }
        public byte[] CleanPhoto
        {
            get
            {
                if (OleImageHelper.HasOleHeader(Photo))
                    return OleImageHelper.RemoveOldeHeader(Photo);
                return Photo;
            }
        }
    }
    public class StaffTerritory
    {
        public int StaffId { get; set; }
        public string TerritoryId { get; set; }
        public string TerritoryName { get; set; }
    }
}
