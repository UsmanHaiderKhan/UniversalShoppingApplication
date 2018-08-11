using System.ComponentModel.DataAnnotations;

namespace UniversalShopingClasses.GeneralProductManagement
{
    public class ProductBrand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ProductType ProductType { get; set; }
    }
}
