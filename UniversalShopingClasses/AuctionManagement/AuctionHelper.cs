using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UniversalShopingClasses.AuctionManagement
{
    public static class AuctionHelper
    {
        //public static List<SelectListItem> ToSelectItemList(IEnumerable<IBidable> values)
        //{
        //    List<SelectListItem> tempList = new List<SelectListItem>();
        //    foreach (var v in values)
        //    {
        //        tempList.Add(new SelectListItem { Text = v.Name, Value = Convert.ToString(v.Id) });
        //    }
        //    return tempList;
        //}
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
        public static List<AuctionSummery> AuctionSummeryList(IEnumerable<Auction> auction)
        {
            List<AuctionSummery> temp = new List<AuctionSummery>();
            if (auction != null)
            {
                temp.AddRange(auction.Select(c => ToAuctionSummary(c)));
                temp.TrimExcess();
            }
            return temp;
        }

        public static List<AuctionSummery> ToAuctinoSummeryModelList(this List<Auction> auctions)
        {
            List<AuctionSummery> tempList = new List<AuctionSummery>();
            foreach (var adv in auctions)
            {
                AuctionSummery m = new AuctionSummery();
                m.Id = adv.Id;
                m.Name = adv.Name;
                m.BidPrice = adv.BidPrice;
                m.ImageUrl = (adv.ProductImages.Count > 0) ? adv.ProductImages.First().Url : "/images/temp/nophoto.png";
                tempList.Add(m);
            }
            tempList.TrimExcess();
            return tempList;
        }
        public static AuctionSummery ToAuctionSummary(Auction auction)
        {
            return new AuctionSummery()
            {
                Id = auction.Id,
                Name = auction.Name,
                BidPrice = auction.BidPrice,
                Description = auction.Description,
                ImageUrl = (auction.ProductImages.Count > 0) ? auction.ProductImages.First().Url : null
            };
        }
    }
}
