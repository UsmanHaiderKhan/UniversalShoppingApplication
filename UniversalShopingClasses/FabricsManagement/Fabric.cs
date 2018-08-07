using System.Collections.Generic;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingClasses.FabricsManagement
{
    public class Fabric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }

        public Fabric()
        {
            ProductImages = new List<ProductImages>();
        }

    }
}
