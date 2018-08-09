using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversalShopingClasses.FabricsManagement
{
    public class FabricHandler
    {
        UniversalContext db = new UniversalContext();
        public List<Fabric> GetAllProducts()
        {
            using (db)
            {
                return (from c in db.Fabrics
                        .Include(m => m.ProductBrand)
                        .Include(m => m.ProductImages)
                        select c).ToList();
            }
        }

        public Fabric GetFabricById(int id)
        {
            using (db)
            {
                return (from c in db.Fabrics
                        .Include(m => m.ProductBrand)
                        .Include(m => m.ProductImages)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

    }
}
