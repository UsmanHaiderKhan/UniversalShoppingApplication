using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingClasses;
using UniversalShopingClasses.AuctionManagement;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingApp.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        public ActionResult Index()
        {
            User user = (User)Session[WebUtils.Current_User];
            if (!(user != null && user.IsInRole(WebUtils.Admin)))
                return RedirectToAction("Login", "Users", new { ctl = "Feedback", act = "GetFeedBack" });
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
            User user = (User)Session[WebUtils.Current_User];
            if (!(user != null && user.IsInRole(WebUtils.Admin)))
                return RedirectToAction("Login", "Users", new { ctl = "Feedback", act = "DeleteFeedBack" });
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
