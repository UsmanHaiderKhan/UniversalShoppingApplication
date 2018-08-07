using System;
using System.Collections.Generic;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingClasses.MobileManagement
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public bool BlueTooth { get; set; }
        public bool ThreeG { get; set; }
        public bool FourG { get; set; }
        public bool Wifi { get; set; }
        public int Ram { get; set; }
        public int FrontCam { get; set; }
        public int BackCam { get; set; }
        public string Color { get; set; }
        public int ScreenSize { get; set; }
        public int Battery { get; set; }
        public int? Stock { get; set; }
        public string Accessories { get; set; }
        public DateTime Warranty { get; set; }
        public string Features { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual ProductBrand ProductBrand { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }

        public Mobile()
        {
            ProductImages = new List<ProductImages>();
        }

    }
}
