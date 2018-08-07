using System.Data.Entity;
using UniversalShopingClasses.CartManagement;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.FabricsManagement;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.MobileManagement;
using UniversalShopingClasses.OLXClass;
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
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductImages> Imageses { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }


        //OLXClass WORK

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementSubCategory> AdvertisementSubCategories { get; set; }
        public DbSet<AdvertismentCateory> AdvertismentCateories { get; set; }
        public DbSet<AdvertisementType> AdvertisementTypes { get; set; }







    }
}
