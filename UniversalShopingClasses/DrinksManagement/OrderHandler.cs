using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversalShopingClasses.DrinksManagement
{
    public class OrderHandler
    {
        public List<DrinkOrderDetail> GetAllOrders()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.DrinkOrderDetails select c).ToList();
            }
        }

        public List<DrinkOrder> GetOrders()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.DrinkOrders.Include(m => m.OrderDetails).Include(m => m.OrderStatus) select c).ToList();
            }
        }

        public List<DrinkOrder> GetOrdersDetails(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from s in db.DrinkOrders
                        .Include(t => t.OrderDetails)
                        where s.Id == id
                        select s).ToList();
            }
        }

        public DrinkOrderDetail GetOrderDetailById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.DrinkOrderDetails where c.Id == id select c).FirstOrDefault();
            }
        }

        public DrinkOrderStatus GetOrderStatusById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.OrderStatuses where c.Id == id select c).FirstOrDefault();
            }
        }


        public List<DrinkOrderDetail> GetAllBuyedDrink(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.DrinkOrderDetails where c.Id == id select c).ToList();
            }
        }
    }
}
