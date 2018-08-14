using System;
using System.Web.Mvc;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingApp.Controllers
{
    public class AuctionChatController : Controller
    {
        // GET: AuctionChat
        public ActionResult Index()
        {
            User user = (User)Session[WebUtils.Current_User];
            if (!(user != null && user.IsInRole(Convert.ToInt32(WebUtils.Current_User))))
                return RedirectToAction("Login", "Users", new { ctl = "Login", act = "Users" });
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}
