using System;
using System.Collections.Generic;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingClasses.AuctionManagement
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BidPrice { get; set; }
        public string Specification { get; set; }
        public DateTime Postedon { get; set; }
        public string Description { get; set; }
        public AuctionCategory AuctionCategory { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }

        public Auction()
        {
            ProductImages = new List<ProductImages>();

        }
    }
}
