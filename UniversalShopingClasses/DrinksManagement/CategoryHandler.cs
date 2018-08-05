using System.Collections.Generic;
using System.Linq;

namespace UniversalShopingClasses.DrinksManagement
{
    public class CategoryHandler
    {
        UniversalContext db = new UniversalContext();

        public List<DrinkCategory> GetAllCategories()
        {
            using (db)
            {
                return (from c in db.DrinkCategories select c).ToList();
            }
        }
    }
}
