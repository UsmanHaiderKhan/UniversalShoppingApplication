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

        public List<Advertisement> GetLatestAdvertisements(int count)
        {
            using (UniversalContext context = new UniversalContext())
            {
                return (from adv in context.Advertisements
                        .Include(a => a.SubCategory.AdvertismentCateory)
                       .Include(a => a.Images)
                       .Include(a => a.Type)
                        orderby adv.PostedOn
                        select adv).Take(count).ToList();
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

                        .Include(a => a.Images)
                      .Include(a => a.Type)
                        where adv.SubCategory.AdvertismentCateory.Id == advertisementCategory.Id
                        select adv).ToList();
            }
        }

        public List<Advertisement> GetAllAdvertisement()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Advertisements
                        .Include(m => m.SubCategory)
                        .Include(m => m.Images)
                        select c).ToList();
            }
        }

        public List<Advertisement> GetAllAdvertisementById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Advertisements
                        .Include(m => m.SubCategory)
                        .Include(m => m.Images)
                        select c).ToList();
            }
        }
    }
}
