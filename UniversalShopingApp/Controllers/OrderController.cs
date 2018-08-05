using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingClasses;
using UniversalShopingClasses.DrinksManagement;

namespace UniversalShopingApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReciveOrders()
        {
            List<DrinkOrderDetail> orders = new OrderHandler().GetAllOrders();
            return View(orders);
        }
        public int GetOrdersCount()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from o in db.DrinkOrderDetails select o).Count();
            }
        }

        public ActionResult Orderby()
        {
            List<DrinkOrder> orders = new OrderHandler().GetOrders();
            return View(orders);
        }
        public ActionResult DeleteOrdersBy(int id)
        {
            UniversalContext db = new UniversalContext();
            DrinkOrder p = (from c in db.DrinkOrders.Include(x => x.OrderDetails) where c.Id == id select c).FirstOrDefault();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);


        }
        public ActionResult OrderView(int id)
        {
            OrderHandler ph = new OrderHandler();
            List<DrinkOrder> pl = ph.GetOrders();
            ViewBag.POrders = pl;
            List<DrinkOrder> orders = new OrderHandler().GetOrdersDetails(id);
            return View(orders);
        }
        public ActionResult DeleteOrders(int id)
        {
            UniversalContext db = new UniversalContext();
            DrinkOrderDetail p = (from c in db.DrinkOrderDetails where c.Id == id select c).FirstOrDefault();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);


        }


        public int GetOrderByCount()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.DrinkOrders select c).Count();
            }
        }

        [HttpGet]
        public ActionResult UpdateOrder(int id)
        {
            DrinkOrderDetail orderDetail = new OrderHandler().GetOrderDetailById(id);
            return View(orderDetail);
        }
        [HttpPost]
        public ActionResult UpdateOrder(DrinkOrderDetail orderDetail)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ReciveOrders");
        }
    }

}
