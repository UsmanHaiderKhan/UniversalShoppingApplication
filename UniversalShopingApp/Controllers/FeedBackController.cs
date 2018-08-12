using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingClasses;
using UniversalShopingClasses.AuctionManagement;

namespace UniversalShopingApp.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        public ActionResult Index()
        {
            List<FeedBack> feed = new AuctionHandler().GetAllFeedBacks();
            return View(feed);
        }
        [HttpGet]
        public ActionResult PostFeedBack()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostFeedBack(FeedBack feedBack)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                db.FeedBacks.Add(feedBack);
                db.SaveChanges();
            }
            return RedirectToAction("Thanks", "FeedBack");
        }

        public ActionResult Thanks()
        {
            return View();
        }

        public ActionResult DeleteFeedBack(int id)
        {
            UniversalContext db = new UniversalContext();
            FeedBack feedBack = (from c in db.FeedBacks
                                 where c.Id == id
                                 select c).FirstOrDefault();
            db.Entry(feedBack).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
    }
}
