using System.Collections.Generic;

namespace UniversalShopingClasses.DrinksManagement
{
    public class DrinkOrder
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string EmailAddress { get; set; }
        public string FullAddress { get; set; }
        public bool IsActive { get; set; }
        public double Phone { get; set; }
        public DrinkOrderStatus OrderStatus { get; set; }
        public List<DrinkOrderDetail> OrderDetails { get; set; }

    }
}
