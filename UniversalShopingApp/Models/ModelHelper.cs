using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.MobileManagement;

namespace UniversalShopingApp.Models
{
    public class ModelHelper
    {
        public static List<SelectListItem> ToSelectItemList(dynamic values)

        {
            List<SelectListItem> templist = null;
            if (values != null)
            {
                templist = new List<SelectListItem>();
                foreach (var v in values)
                {
                    templist.Add(new SelectListItem { Text = v.Name, Value = Convert.ToString(v.Id) });
                }
                templist.TrimExcess();
            }
            return templist;
        }
        public static List<ProductSummeryModel> ProductSummeryList(IEnumerable<Drink> drinkes)
        {
            List<ProductSummeryModel> temp = new List<ProductSummeryModel>();
            if (drinkes != null)
            {
                temp.AddRange(drinkes.Select(m => ToProductSummary(m)));
                temp.TrimExcess();
            }
            return temp;
        }
        public static List<MobileHelper> ProductSummeryListOfMobiles(IEnumerable<Mobile> mobiles)
        {
            List<MobileHelper> temp = new List<MobileHelper>();
            if (mobiles != null)
            {
                temp.AddRange(mobiles.Select(c => ToProductSummaryMobile(c)));
                temp.TrimExcess();
            }
            return temp;
        }
        public static ProductSummeryModel ToProductSummary(Drink drink)
        {
            return new ProductSummeryModel
            {
                Id = drink.Id,
                Name = drink.Name,
                Price = drink.Price,
                ShortDescription = drink.ShortDescription,
                ImageUrl = (drink.ProductImages.Count > 0) ? drink.ProductImages.First().Url : null
            };
        }
        public static MobileHelper ToProductSummaryMobile(Mobile mobile)
        {
            return new MobileHelper()
            {
                Id = mobile.Id,
                Name = mobile.Name,
                Price = mobile.Price,
                Description = mobile.Description,
                ImageUrl = (mobile.ProductImages.Count > 0) ? mobile.ProductImages.First().Url : null
            };
        }
    }
}
