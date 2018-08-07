using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingClasses.MobileManagement
{
    public class MobileHandler
    {
        public List<Mobile> GetMobilebyId(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Mobiles.Include(m => m.ProductImages).Include(m => m.ProductBrand)
                        where c.Id == id
                        select c).ToList();
            }
        }
        public List<Mobile> GetMobileByBrand(ProductBrand mobileBrand)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return
                (from m in
                        db.Mobiles
                            .Include(m => m.ProductBrand)
                            .Include(m => m.ProductImages)
                 where m.ProductBrand.Id == mobileBrand.Id
                 select m).ToList();
            }
        }
        public ProductBrand GetBrandById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.ProductBrands
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<Mobile> GetAllMobiles()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Mobiles select c).ToList();
            }
        }
    }
}
