using System.Linq;

namespace UniversalShopingClasses.GeneralProductManagement
{
    public class ProductHandler
    {
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
