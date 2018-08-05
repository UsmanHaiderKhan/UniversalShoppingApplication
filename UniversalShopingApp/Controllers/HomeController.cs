using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.products = ModelHelper.ProductSummeryList(new DrinkHandler().GetLatestDrinks(6));
            return View();
        }
        [HttpGet]
        public ActionResult ByCategory(int id)
        {
            ViewBag.ByCategory = ModelHelper.ProductSummeryList(new DrinkHandler().GetDrinksByCategory(new DrinkCategory { Id = id }));
            DrinkCategory mb = new DrinkHandler().GetCategoryById(id);
            return View(mb);
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            List<Drink> drink = new DrinkHandler().GetDrinkbyId(id);
            return View(drink);
        }

        [HttpGet]
        public ActionResult ViewOrderDetails()
        {
            User user = (User)Session[WebUtils.Current_User];
            UniversalContext db = new UniversalContext();
            List<DrinkOrder> orders;
            using (db)
            {
                orders = (from c in db.DrinkOrders
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
