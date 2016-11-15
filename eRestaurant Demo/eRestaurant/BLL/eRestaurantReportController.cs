using eRestaurant.DAL;
using eRestaurant.Entities.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class eRestaurantReportController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItem> GetReportCategoryMenuItems()
        {
            using (var context = new RestaurantContext())
            {
                var results = from row in context.Items
                //                \row/ is an instance of the Item entity
                              select new CategoryMenuItem()
                              {
                                  CategoryDescription = row.MenuCategory.Description,
                                  ItemDescription = row.Description,
                                  Price = row.CurrentPrice,
                                  Calories = row.Calories,
                                  Comment = row.Comment
                              };

                return results.ToList();
            }
        }
    }
}
