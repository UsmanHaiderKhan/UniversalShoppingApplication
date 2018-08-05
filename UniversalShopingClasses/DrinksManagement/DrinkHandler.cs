using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversalShopingClasses.DrinksManagement
{
    public class DrinkHandler
    {
        public List<Drink> GetLatestDrinks(int counter)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from m in db.Drinks
                        .Include(m => m.Category)
                        .Include(m => m.ImageUrl)
                        orderby m.Name descending
                        select m).Take(counter).ToList();
            }
        }
        public List<Drink> GetDrinksByCategory(DrinkCategory category)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return
                    (from m in
                            db.Drinks
                                .Include(m => m.Category)
                                .Include(m => m.ImageUrl)
                     where m.Category.Id == category.Id
                     select m).ToList();
            }
        }
        public DrinkCategory GetCategoryById(int id)
        {
            using (UniversalContext db = new UniversalContext())
            {
                return (from b in db.DrinkCategories
                        where b.Id == id
                        select b).FirstOrDefault();
            }
        }
        public DrinkOrder GetOrderById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.DrinkOrders.Include(m => m.OrderDetails) where c.Id == id select c).FirstOrDefault();
            }
        }
        public List<Drink> GetDrinkbyId(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks.Include(m => m.ImageUrl).Include(m => m.Category) where c.Id == id select c).ToList();
            }
        }

        public List<Drink> GetAllDrinks()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks.Include(m => m.Category).Include(m => m.ImageUrl) select c).ToList();
            }

        }

        public Drink GetSingleDrink(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks.Include(m => m.Category).Include(m => m.ImageUrl) where c.Id == id select c)
                    .FirstOrDefault();
            }
        }
    }
}
