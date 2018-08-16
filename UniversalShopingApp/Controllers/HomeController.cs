using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.CartManagement;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.FabricsManagement;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.MobileManagement;

namespace UniversalShopingApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.products = ModelHelper.ProductSummeryList(new DrinkHandler().GetLatestDrinks(6));
            ViewBag.Mobiles = ModelHelper.ProductSummeryList(new DrinkHandler().GetLastestMobiles(6));
            ViewBag.Fabrics = ModelHelper.ProductSummeryList(new DrinkHandler().GetLastestFabrics(6));
            return View();
        }
        [HttpGet]
        public ActionResult ByCategory(int id)
        {
            ViewBag.DrinksByCategory = ModelHelper.ProductSummeryList(new ProductHandler().GetDrinksType(id));
            ViewBag.MobileByCategory = ModelHelper.ProductSummeryList(new ProductHandler().GetMobilesType(id));
            ViewBag.FabricsByCategory = ModelHelper.ProductSummeryList(new ProductHandler().GetFabricssType(id));
            return View();
        }

        public ActionResult MobileByCategory(int id)
        {
            ViewBag.MobileByCategory = ModelHelper.ProductSummeryList(new MobileHandler().GetMobileByBrand(new ProductBrand { Id = id }));

            return View();
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
        public ActionResult FabricsDetail(int id)
        {
            List<Fabric> fabrics = new FabricHandler().GetFabricByid(id);
            return View(fabrics);
        }
        [HttpGet]
        public ActionResult ViewOrderDetails()
        {
            //User user = (User)Session[WebUtils.Current_User];

            UniversalContext db = new UniversalContext();
            List<Order> orders;
            using (db)
            {
                orders = (from c in db.Orders
                       .Include(m => m.OrderDetails)
                       .Include(m => m.OrderStatus)
                          select c).ToList();
            }
            return View(orders);
        }
        [HttpGet]
        public ActionResult TrackOrder()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TrackOrder(FormCollection fdata)
        {
            UniversalContext db = new UniversalContext();
            string orderno = Convert.ToString(fdata["orderno"]);
            Order order = db.Orders.Include(f => f.OrderDetails)
                .Include(f => f.OrderStatus).FirstOrDefault(f => f.OrderNo == orderno);

            return View(order);
        }

        [HttpGet]
        public ActionResult ViewPlaceOrder(string orderNo)
        {
            UniversalContext db = new UniversalContext();
            Order order = new Order();
            using (db)
            {
                order = (from c in db.Orders.Include(m => m.OrderDetails).Include(m => m.OrderStatus)
                         where c.OrderNo == orderNo
                         select c).FirstOrDefault();
            }

            return View(order);
        }


    }
}
