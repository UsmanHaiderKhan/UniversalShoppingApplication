using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversalShopingClasses.OLXClass
{
    public class AdvertisemntHandler
    {
        public List<AdvertisementType> GetTypes()
        {
            using (UniversalContext db = new UniversalContext())
            {
                return (from t in db.AdvertisementTypes
                        select t).ToList();
            }
        }

        public List<AdvertismentCateory> GetCategories()
        {
            using (UniversalContext context = new UniversalContext())
            {
                return (from c in context.AdvertismentCateories
                        select c).ToList();
            }
        }

        public List<AdvertisementSubCategory> GetSubCategories(AdvertismentCateory category)
        {
            using (UniversalContext context = new UniversalContext())
            {
                return (from sc in context.AdvertisementSubCategories
                       .Include(m => m.AdvertismentCateory)
                        where sc.AdvertismentCateory.Id == category.Id
                        select sc).ToList();
            }
        }

        public List<Advertisement> GetAdvertisementsByCategory(AdvertismentCateory advertisementCategory)
        {
            using (UniversalContext context = new UniversalContext())
            {
                return (from adv in context.Advertisements
                        .Include(a => a.SubCategory.AdvertismentCateory)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                      .Include(a => a.Type)
                        where adv.SubCategory.AdvertismentCateory.Id == advertisementCategory.Id
                        select adv).ToList();
            }
        }
    }
}
