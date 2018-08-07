using System.Collections.Generic;

namespace UniversalShopingClasses.CartManagement
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string EmailAddress { get; set; }
        public string FullAddress { get; set; }
        public bool IsActive { get; set; }
        public double Phone { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
