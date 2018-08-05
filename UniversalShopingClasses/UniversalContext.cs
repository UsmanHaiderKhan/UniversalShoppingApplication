using System.Data.Entity;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingClasses
{
    public class UniversalContext : DbContext
    {
        public UniversalContext() : base("name=constr")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkOrder> DrinkOrders { get; set; }
        public DbSet<DrinkOrderDetail> DrinkOrderDetails { get; set; }
        public DbSet<ProductImages> ProductImageses { get; set; }
        public DbSet<DrinkOrderStatus> OrderStatuses { get; set; }




    }
}
