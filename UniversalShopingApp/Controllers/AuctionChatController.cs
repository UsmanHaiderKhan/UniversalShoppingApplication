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
            if (user == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}
