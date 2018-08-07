using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UniversalShopingClasses.OLXClass
{
    public static class ListHelper
    {
        public static List<SelectListItem> ToSelectItemList(this IEnumerable<IListable> values)
        {
            List<SelectListItem> tempList = new List<SelectListItem>();
            foreach (var v in values)
            {
                tempList.Add(new SelectListItem { Text = v.Name, Value = Convert.ToString(v.Id) });
            }
            return tempList;
        }

        public static List<AdvSummeryModel> ToAdvSumModelList(this List<Advertisement> advertisements)
        {
            List<AdvSummeryModel> tempList = new List<AdvSummeryModel>();
            foreach (var adv in advertisements)
            {
                AdvSummeryModel m = new AdvSummeryModel();
                m.Id = adv.Id;
                m.Title = adv.Title;
                m.Price = adv.Price;
                m.ImageUrl = (adv.Images.Count > 0) ? adv.Images.First().Url : "/images/temp/nophoto.png";
                tempList.Add(m);
            }
            tempList.TrimExcess();
            return tempList;
        }
    }
}
