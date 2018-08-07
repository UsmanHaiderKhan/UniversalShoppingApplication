using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.FabricsManagement;
using UniversalShopingClasses.MobileManagement;

namespace UniversalShopingApp.Models
{
    public static class ModelHelper
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
        public static List<ProductSummeryModel> ProductSummeryList(IEnumerable<Mobile> mobiles)
        {
            List<ProductSummeryModel> temp = new List<ProductSummeryModel>();
            if (mobiles != null)
            {
                temp.AddRange(mobiles.Select(c => ToProductSummary(c)));
                temp.TrimExcess();
            }
            return temp;
        }
        public static List<ProductSummeryModel> ProductSummeryList(IEnumerable<Fabric> fabricss)
        {
            List<ProductSummeryModel> temp = new List<ProductSummeryModel>();
            if (fabricss != null)
            {
                temp.AddRange(fabricss.Select(c => ToProductSummary(c)));
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
        public static ProductSummeryModel ToProductSummary(Mobile mobile)
        {
            return new ProductSummeryModel
            {
                Id = mobile.Id,
                Name = mobile.Name,
                Price = mobile.Price,
                ShortDescription = mobile.Description,
                ImageUrl = (mobile.ProductImages.Count > 0) ? mobile.ProductImages.First().Url : null
            };
        }

        public static ProductSummeryModel ToProductSummary(Fabric fabric)
        {
            return new ProductSummeryModel
            {
                Id = fabric.Id,
                Name = fabric.Name,
                Price = fabric.Price,
                ShortDescription = fabric.Description,
                ImageUrl = (fabric.ProductImages.Count > 0) ? fabric.ProductImages.First().Url : null
            };
        }

    }
}
