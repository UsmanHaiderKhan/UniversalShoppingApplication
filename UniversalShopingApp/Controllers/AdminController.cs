using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingClasses;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult GetAllUsers()
        {
            //User user = (User)Session[WebUtils.Current_User];//for  Seeing Admin
            //if (!(user != null && user.IsInRole(WebUtils.Admin)))
            //    return RedirectToAction("Login", "Users", new { ctl = "Admin", act = "Index" });
            List<User> users = new UserHandler().GetUsers();
            return View(users);
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            //User user = (User)Session[WebUtils.Current_User];//for  Seeing Admin
            //if (!(user != null && user.IsInRole(WebUtils.Admin)))
            //    return RedirectToAction("Login", "Users", new { ctl = "Admin", act = "Index" });

            User user1 = new UserHandler().GetUserById(id);
            return View(user1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UpdateUser(User u)
        {
            //User user = (User)Session[WebUtils.Current_User];//for  Seeing Admin
            //if (!(user != null && user.IsInRole(WebUtils.Admin)))
            //    return RedirectToAction("Login", "Users", new { ctl = "Admin", act = "Index" });

            UniversalContext db = new UniversalContext();
            if (ModelState.IsValid)
            {
                using (db)
                {
                    User oldUser = db.Users.Find(u.Id);
                    oldUser.Role = u.Role;
                    oldUser.Fullname = u.Fullname;
                    oldUser.City = u.City;
                    oldUser.State = u.State;
                    oldUser.ConfirmPassword = u.ConfirmPassword;
                    oldUser.Password = u.Password;
                    oldUser.Loginid = u.Loginid;
                    oldUser.ImageUrl = u.ImageUrl;
                    oldUser.MobileNo = u.MobileNo;
                    oldUser.Email = u.Email;
                    oldUser.FullAddress = u.FullAddress;
                    db.Entry(oldUser).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("GetAllUsers", "Admin");
            }

            return View();

        }
        public int GetUserCount()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Users select c).Count();
            }
        }
        public int GetOrderCount()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Orders select c).Count();
            }
        }
        public int GetDrinkCount()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Drinks select c).Count();
            }
        }
        public int GetMobileCount()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Mobiles select c).Count();
            }
        }
    }
}
