using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.CartManagement;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.MobileManagement;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.products = ModelHelper.ProductSummeryList(new DrinkHandler().GetLatestDrinks(6));
            ViewBag.Mobiles = ModelHelper.ProductSummeryListOfMobiles(new DrinkHandler().GetLastestMobiles(9));
            return View();
        }
        [HttpGet]
        public ActionResult ByCategory(int id)
        {
            ViewBag.ByCategory = ModelHelper.ProductSummeryList(new DrinkHandler().GetDrinksByCategory(new ProductBrand { Id = id }));
            ProductBrand mb = new DrinkHandler().GetCategoryById(id);
            return View(mb);
        }

        public ActionResult MobileByCategory(int id)
        {
            ViewBag.MobileByCategory = ModelHelper.ProductSummeryListOfMobiles(new MobileHandler().GetMobileByBrand(new ProductBrand { Id = id }));
            ProductBrand mb = new MobileHandler().GetBrandById(id);
            return View(mb);
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            List<Drink> drink = new DrinkHandler().GetDrinkbyId(id);
            return View(drink);
        }
        [HttpGet]
        public ActionResult MobileDetails(int id)
        {
            List<Mobile> mobiles = new MobileHandler().GetMobilebyId(id);
            return View(mobiles);
        }

        [HttpGet]
        public ActionResult ViewOrderDetails()
        {
            User user = (User)Session[WebUtils.Current_User];
            UniversalContext db = new UniversalContext();
            List<Order> orders;
            using (db)
            {
                orders = (from c in db.Orders
                       .Include(m => m.OrderDetails)
                       .Include(m => m.OrderStatus)
                          where c.BuyerName == user.Fullname
                          where c.FullAddress == user.FullAddress
                          where c.EmailAddress == user.Email
                          select c).ToList();
            }
            return View(orders);
        }

    }
}
