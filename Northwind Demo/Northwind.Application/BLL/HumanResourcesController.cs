using Northwind.Application.BLL.Adapters;
using Northwind.Application.DataModels;
using Northwind.Application.DataModels.Commands;
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
        #region Business Processes
        #region Commands
        public void AssignEmployeeTerritory(TerritoryAssignment assignment)
        {
            using (var context = new NorthwindContext())
            {
                var employee = context.Employees.Find(assignment.EmployeeId);
                var territory = context.Territories.Find(assignment.TerritoryId);
                employee.Territories.Add(territory);

                context.SaveChanges();
            }
        }

        public void RemoveTerritoryAssignment(TerritoryAssignment assignment)
        {
            using (var context = new NorthwindContext())
            {
                var employee = context.Employees.Find(assignment.EmployeeId);
                var territory = context.Territories.Find(assignment.TerritoryId);
                employee.Territories.Remove(territory);

                context.SaveChanges();
            }
        }

        public void HireEmployee(NewEmployeeProfile profile)
        {
            using (var context = new NorthwindContext())
            {
                if (profile.RawPhoto != null)
                    profile.RawPhoto = OleImageHelper.AddOleHeader(profile.RawPhoto);
                var employee = new Employee()
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Title = profile.Title,
                    TitleOfCourtesy = profile.TitleOfCourtesy,
                    BirthDate = profile.BirthDate,
                    HireDate = profile.StartDate,
                    Address = profile.Address,
                    City = profile.City,
                    Region = profile.Region,
                    PostalCode = profile.PostalCode,
                    Country = profile.Country,
                    HomePhone = profile.HomePhone,
                    Extension = profile.Extension,
                    Photo = profile.RawPhoto,
                    Notes = profile.Notes,
                    ReportsTo = profile.Supervisor
                };
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void FireEmployee(int employeeId, IEnumerable<TerritoryAssignment> reassignedTerritories)
        {
            // TODO: FireEmployee - Required change to Employees table (add nullable ReleaseDate)
        }
        #endregion
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Territory> ListUnassignedTerritories()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Territories
                              where data.Employees.Count == 0
                              select data;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DropDownData> ListStaffNames()
        {
            using (var context = new NorthwindContext())
            {
                var result = from data in context.Employees
                             select new DropDownData()
                             {
                                 DataText = data.FirstName + " " + data.LastName,
                                 DataValue = data.EmployeeID.ToString()
                             };
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<StaffProfile> ListStaff()
        {
            using (var context = new NorthwindContext())
            {
                var result = from data in context.Employees
                             select new StaffProfile()
                             {
                                 Name = data.FirstName + " " + data.LastName,
                                 JobTitle = data.Title,
                                 HireDate = data.HireDate,
                                 Photo = data.Photo,
                                 Id = data.EmployeeID,
                                 Territories = from place in data.Territories
                                               orderby place.TerritoryDescription
                                               select new StaffTerritory()
                                               {
                                                   StaffId = data.EmployeeID,
                                                   TerritoryId = place.TerritoryID,
                                                   TerritoryName = place.TerritoryDescription
                                               }
                                 // Yearly Sales/Order count

                             };
                return result.ToList();
            }
        }

        // TODO: GetEmployeeRegionalManagementReport
        #endregion
        #endregion

        #region CRUD - Sales Regions/Territories
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
