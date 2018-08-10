using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversalShopingClasses.AuctionManagement
{
    public class AuctionHandler
    {
        UniversalContext db = new UniversalContext();
        public List<Auction> GetAllAuctions()
        {
            using (db)
            {
                return (from c in db.Auctions
                        .Include(m => m.AuctionCategory)
                        .Include(m => m.ProductImages)
                        select c).ToList();
            }
        }

        public List<Auction> GetLatestAuction(int count)
        {
            using (db)
            {
                return (from adv in db.Auctions
                        .Include(a => a.AuctionCategory)
                        .Include(a => a.ProductImages)
                        orderby adv.Postedon
                        select adv).Take(count).ToList();
            }
        }
        public object GetCategories()
        {
            using (db)
            {
                return (from c in db.AuctionCategories
                        select c).ToList();
            }
        }
        public Auction GetAuctionById(int id)
        {
            using (db)
            {
                return (from c in db.Auctions
                        .Include(m => m.AuctionCategory)
                        .Include(m => m.ProductImages)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
}
