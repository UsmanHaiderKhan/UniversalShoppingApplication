using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingClasses.DrinksManagement
{
    public class Drink
    {
        public int Id { get; set; }
        [Display(Name = "Drink Name")]
        public string Name { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool IsPreferredDrink { get; set; }
        public bool InStock { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }

        public Drink()
        {
            ProductImages = new List<ProductImages>();
        }
    }

}
