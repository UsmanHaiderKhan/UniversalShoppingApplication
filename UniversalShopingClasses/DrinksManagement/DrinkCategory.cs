using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace UniversalShopingClasses.DrinksManagement
{
    public class DrinkCategory
    {
        public int Id { get; set; }
        [Display(Name = "Drink Category")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
