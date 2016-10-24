using Chinook.Framework.DAL;
using Chinook.Framework.DAL.Security;
using Chinook.Framework.Entities.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic; // NEW
using System.ComponentModel;  // NEW
using System.Linq;

namespace Chinook.Framework.BLL.Security
{
    [DataObject]
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }

        #region Constants
        private const string STR_DEFAULT_PASSWORD = "Pa$$word1";
        /// <summary>Requires FirstName and Lastname</summary>
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        /// <summary>Requires UserName</summary>
        private const string STR_EMAIL_FORMAT = "{0}@ChinookLab.tba";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";
        #endregion

        public void AddWebMaster()
        {
            if(!Users.Any(u=>u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var webMasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                this.Create(webMasterAccount, STR_DEFAULT_PASSWORD);
                this.AddToRole(webMasterAccount.Id, SecurityRoles.WebsiteAdmins);
            }
        } // end of AddWebMaster()

        #region Standard CRUD Operations
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<UserProfile> ListAllUsers()
        {
            // The following portion uses the ApplicationDbContext "under the hood"
            var rm = new RoleManager();
            var result = from person in Users.ToList() // .ToList() to grab data from db first
                         select new UserProfile()
                         {
                             UserId = person.Id,
                             UserName = person.UserName,
                             Email = person.Email,
                             EmailConfirmed = person.EmailConfirmed,
                             CustomerId = person.CustomerID,
                             EmployeeId = person.EmployeeID,
                             RoleMemberships = person.Roles.Select(r => rm.FindById(r.RoleId).Name)
                         };

            // The following portion uses the ChinookContext to get first/last names of users
            using (var context = new ChinookContext())
            {
                foreach(var person in result)
                {
                    if(person.EmployeeId.HasValue)
                    {
                        var employee = context.Employees.Find(person.EmployeeId);
                        if(employee != null) // employee was found
                        {
                            person.FirstName = employee.FirstName;
                            person.LastName = employee.LastName;
                        }
                    }
                    else if(person.CustomerId.HasValue)
                    {
                        var customer = context.Customers.Find(person.CustomerId);
                        if(customer != null) // customer was found
                        {
                            person.FirstName = customer.FirstName;
                            person.LastName = customer.LastName;
                        }
                    }
                }
            }

            return result.ToList();
        } // end of ListAllUsers()

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddUser(UserProfile userInfo)
        {
            // Convert the DTO data I received into my Entity data for ApplicationUser
            var userAccount = new ApplicationUser()
            {
                UserName = userInfo.UserName,
                Email = userInfo.Email
            };

            // Add the user account
            this.Create(userAccount, STR_DEFAULT_PASSWORD);
            
            // Add this user to all the roles that were specified in the UserProfile
            foreach (string roleName in userInfo.RoleMemberships)
                this.AddToRole(userAccount.Id, roleName);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void RemoveUser(UserProfile userInfo)
        {
            // TODO:
        }
        #endregion
    }
}
