using Northwind.Data.DAL;
using Northwind.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.BLL
{
    [DataObject]
    public class HumanResourcesController
    {
        #region Sales Regions/Territories
        #region Regions
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Region> ListAllRegions()
        {
            using (var context = new NorthwindContext())
            {
                return context.Regions.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddRegion(Region data)
        {
            using (var context = new NorthwindContext())
            {
                context.Regions.Add(data);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateRegion(Region data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Entry(data);
                existing.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteRegion(Region data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Regions.Find(data.RegionID);
                context.Regions.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Territories
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Territory> ListAllTerritories()
        {
            using (var context = new NorthwindContext())
            {
                return context.Territories.Include(x=>x.Region).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                context.Territories.Add(data);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Entry(data);
                existing.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Territories.Find(data.TerritoryID);
                context.Territories.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion
        #endregion
    }
}
