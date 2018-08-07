using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversalShopingClasses.CartManagement;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.MobileManagement;

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
                            .Include(m => m.ProductBrand)
                           .Include(m => m.ProductImages)
                        orderby m.Name descending
                        select m).Take(counter).ToList();
            }
        }
        public List<Mobile> GetLastestMobiles(int counter)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from m in db.Mobiles
                        .Include(m => m.ProductBrand)
                        .Include(m => m.ProductImages)
                        orderby m.Name descending
                        select m).Take(counter).ToList();
            }
        }
        public List<Drink> GetDrinksByCategory(ProductBrand category)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return
                    (from m in
                            db.Drinks
                                .Include(m => m.ProductBrand)
                                .Include(m => m.ProductImages)
                     where m.ProductBrand.Id == category.Id
                     select m).ToList();
            }
        }
        public ProductBrand GetCategoryById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.ProductBrands
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
        public List<ProductBrand> GetAllBrands()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.ProductBrands
                        select c).ToList();
            }
        }
        public Order GetOrderById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Orders.Include(m => m.OrderDetails) where c.Id == id select c).FirstOrDefault();
            }
        }
        public List<Drink> GetDrinkbyId(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks
                           .Include(m => m.ProductBrand)
                           .Include(m => m.ProductImages)
                        where c.Id == id
                        select c).ToList();
            }
        }

        public List<Drink> GetAllDrinks()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks
                    .Include(m => m.ProductBrand)
                    .Include(m => m.ProductImages)
                        select c).ToList();
            }

        }

        public Drink GetSingleDrink(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks
                        .Include(m => m.ProductBrand)
                        .Include(m => m.ProductImages)
                        where c.Id == id
                        select c)
                    .FirstOrDefault();
            }
        }
    }
}
