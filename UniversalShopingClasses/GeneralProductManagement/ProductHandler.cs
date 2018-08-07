using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.FabricsManagement;
using UniversalShopingClasses.MobileManagement;

namespace UniversalShopingClasses.GeneralProductManagement
{
    public class ProductHandler
    {
        public List<ProductType> GetAllTypes()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.ProductTypes select c).ToList();
            }

        }

        public ProductType GetProductTypeById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.ProductTypes where c.Id == id select c).FirstOrDefault();
            }
        }

        public List<Drink> GetDrinksType(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks
                    .Include(m => m.ProductImages)
                    .Include(m => m.ProductBrand)
                        where c.ProductBrand.Id == id
                        select c).ToList();
            }
        }

        public List<Mobile> GetMobilesType(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Mobiles
                        .Include(m => m.ProductImages)
                        .Include(m => m.ProductBrand)
                        where c.ProductBrand.Id == id
                        select c).ToList();
            }
        }

        public List<Fabric> GetFabricssType(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Fabrics
                        .Include(m => m.ProductImages)
                        .Include(m => m.ProductBrand)
                        where c.ProductBrand.Id == id
                        select c).ToList();
            }
        }

        public object GetAllCategories()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.ProductBrands select c).ToList();
            }
        }
    }
}
