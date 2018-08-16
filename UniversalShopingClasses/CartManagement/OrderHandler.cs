using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversalShopingClasses.CartManagement
{
    public class OrderHandler
    {
        public List<OrderDetail> GetAllOrders()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.OrderDetails select c).ToList();
            }
        }

        public List<Order> GetOrders()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Orders.Include(m => m.OrderDetails).Include(m => m.OrderStatus) select c).ToList();
            }
        }

        public List<Order> GetOrdersDetails(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from s in db.Orders
                        .Include(t => t.OrderDetails)
                        where s.Id == id
                        select s).ToList();
            }
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.OrderDetails where c.Id == id select c).FirstOrDefault();
            }
        }

        public OrderStatus GetOrderStatusById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.OrderStatuses where c.Id == id select c).FirstOrDefault();
            }
        }


        public List<OrderDetail> GetAllBuyedDrink(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.OrderDetails where c.Id == id select c).ToList();
            }
        }

        public Order GetOrderById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Orders
                        .Include(m => m.OrderStatus)
                        .Include(m => m.OrderDetails)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
}
